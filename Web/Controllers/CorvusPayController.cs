using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Services.Orders;
using Web.Extensions;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Services.Emails;
using SimpleEmailApp.Services.EmailService;
using Web.Models.EmailConfig;
using Web.Models.EmailTemplates;
using Services;
using Services.CorvusPayments;
using System.Security.Claims;
using Web.Models.CorvusPay;

namespace Web.Controllers
{
    public class CorvusPayController : Controller
    {
        private readonly ILogger<CorvusPayController> _logger;
        private readonly IMemoryCache _cache;
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;
        private readonly IErpTempService _erpTempService;
        private readonly IEmailService _emailService;
        private readonly IEmailsService _emailsService;
        private readonly ISecureCredentialsService _credentialsService;
        private readonly IPaymentSessionService _sessionService;

        public CorvusPayController(
            ILogger<CorvusPayController> logger,
            IMemoryCache cache,
            IOrderService orderService,
            IConfiguration configuration,
            IErpTempService erpTempService,
            IEmailService emailService,
            IEmailsService emailsService,
            ISecureCredentialsService credentialsService,
            IPaymentSessionService sessionService)
        {
            _logger = logger;
            _cache = cache;
            _orderService = orderService;
            _configuration = configuration;
            _erpTempService = erpTempService;
            _emailService = emailService;
            _emailsService = emailsService;
            _credentialsService = credentialsService;
            _sessionService = sessionService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> InitiatePaymentFromCheckout(CheckoutFormModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Invalid form data" });
                }

                var cart = model.CartItems ?? new List<CartItem>();
                if (!cart.Any())
                {
                    return Json(new { success = false, message = "Cart is empty" });
                }

                var cartTotal = cart.Sum(item => item.Price * item.Quantity);
                var transportFee = CalculateTransportFee(model.ShipingCountry, cartTotal);
                var totalAmount = cartTotal + transportFee;

                if (totalAmount <= 0)
                {
                    return Json(new { success = false, message = "Invalid order amount" });
                }

                var tempOrderId = $"ORD_{DateTime.UtcNow:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N")[..8]}";
                await StoreTemporaryOrderDataAsync(tempOrderId, model, cart, totalAmount, transportFee);

                var session = await _sessionService.CreateSessionAsync(
                    tempOrderId,
                    totalAmount,
                    User.Identity.Name ?? "anonymous",
                    30); // 30 minutes timeout

                return Json(new
                {
                    success = true,
                    sessionToken = session.Token,
                    orderId = tempOrderId,
                    amount = totalAmount,
                    redirectUrl = Url.Action("CorvusPayment", "CorvusPay", new { orderId = tempOrderId })
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initiating CorvusPay payment from checkout");
                return Json(new { success = false, message = "Payment initiation failed. Please try again." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CorvusPayment(string orderId)
        {
            try
            {
                ViewData["Shared"] = new Dictionary<string, string>();

                var tempOrder = await GetTemporaryOrderDataAsync(orderId);
                if (tempOrder == null)
                {
                    return RedirectToAction("PaymentError", new { error = "Order data not found" });
                }

                var parameters = CreateCorvusPayParameters(tempOrder);
                var signature = GenerateCorvusPaySignature(parameters);

                var model = new CorvusPayRequestVM
                {
                    Version = parameters["version"],
                    StoreId = parameters["store_id"],
                    OrderNumber = parameters["order_number"],
                    Amount = parameters["amount"],
                    Currency = parameters["currency"],
                    Cart = parameters["cart"],
                    RequireComplete = parameters["require_complete"],
                    Language = parameters["language"],
                    SuccessUrl = parameters["success_url"],
                    CancelUrl = parameters["cancel_url"],
                    CallbackUrl = parameters["callback_url"],
                    Signature = signature,
                    PaymentUrl = _configuration["CorvusPaySettings:IsTestMode"] == "true"
        ? _configuration["CorvusPaySettings:TestPaymentUrl"]
        : _configuration["CorvusPaySettings:PaymentUrl"]
                };

                return View("CorvusPayment", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error displaying CorvusPay payment page");
                return RedirectToAction("PaymentError", new { error = "Error loading payment page" });
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> PaymentCallback()
        {
            try
            {
                var formData = new Dictionary<string, string>();
                foreach (var key in Request.Form.Keys)
                {
                    formData[key] = Request.Form[key].ToString();
                }

                // Verify signature
                if (!VerifyCorvusPaySignature(formData))
                {
                    _logger.LogError("Invalid CorvusPay signature");
                    return BadRequest("Invalid signature");
                }

                var orderNumber = formData.GetValueOrDefault("order_number", "");
                var approvalCode = formData.GetValueOrDefault("approval_code", "");
                var transactionId = formData.GetValueOrDefault("transaction_id", "");

                var isSuccess = !string.IsNullOrEmpty(approvalCode) && approvalCode != "000";

                if (isSuccess)
                {
                    var actualOrder = await CreateActualOrderFromTempAsync(orderNumber, transactionId, approvalCode);
                    if (actualOrder != null)
                    {
                        await CleanupTemporaryOrderDataAsync(orderNumber);
                        return RedirectToAction("OrderConfirmation", "Order", new { OrderId = actualOrder.OrderId });
                    }
                }

                return RedirectToAction("OrderFailed", "Order", new
                {
                    ErrorCode = formData.GetValueOrDefault("error_number", ""),
                    ErrorDescription = formData.GetValueOrDefault("error_message", "Payment failed")
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing CorvusPay callback");
                return RedirectToAction("PaymentError", new { error = "Payment processing failed" });
            }
        }

        // Helper Methods
        private decimal CalculateTransportFee(string country, decimal cartTotal)
        {
            if (country == "Hrvatska")
            {
                return cartTotal >= 40 ? 0 : 4.5m;
            }
            return 4.5m;
        }

        private async Task StoreTemporaryOrderDataAsync(string tempOrderId, CheckoutFormModel model, List<CartItem> cart, decimal totalAmount, decimal transportFee)
        {
            var tempOrder = new TemporaryOrderData
            {
                TempOrderId = tempOrderId,
                UserId = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier)?.Value : null,
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                PhoneNumber = model.PhoneNumber,
                ShippingCity = model.ShippingCity,
                ShippingAddress = model.ShippingAddress,
                ShippingPostalCode = model.ShippingPostalCode,
                ShipingCountry = model.ShipingCountry,
                TransportFee = transportFee,
                TotalAmount = totalAmount,
                CartItems = cart.Select(item => new TemporaryOrderItem
                {
                    ProductCode = item.ProductCode,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    SelectedSize = item.SelectedSize,
                    ImagePath = item.ImagePath,
                    GTN = item.GTN
                }).ToList(),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30)
            };

            var cacheKey = $"temp_order_{tempOrderId}";
            _cache.Set(cacheKey, tempOrder, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = tempOrder.ExpiresAt,
                Size = 1
            });
        }

        private async Task<TemporaryOrderData> GetTemporaryOrderDataAsync(string tempOrderId)
        {
            var cacheKey = $"temp_order_{tempOrderId}";
            _cache.TryGetValue(cacheKey, out TemporaryOrderData tempOrder);
            return tempOrder;
        }

        private Dictionary<string, string> CreateCorvusPayParameters(TemporaryOrderData tempOrder)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var amountInCents = ((int)(tempOrder.TotalAmount * 100)).ToString();

            return new Dictionary<string, string>
            {
                ["version"] = "1.3",
                ["store_id"] = _configuration["CorvusPaySettings:StoreId"] ?? "TEST_STORE",
                ["order_number"] = tempOrder.TempOrderId,
                ["amount"] = amountInCents,
                ["currency"] = "HRK",
                ["cart"] = GenerateCartString(tempOrder.CartItems),
                ["require_complete"] = "false",
                ["language"] = "hr",
                ["success_url"] = $"{baseUrl}/hr/corvuspay/paymentsuccess?orderId={tempOrder.TempOrderId}",
                ["cancel_url"] = $"{baseUrl}/hr/corvuspay/paymentcancel?orderId={tempOrder.TempOrderId}",
                ["callback_url"] = $"{baseUrl}/hr/corvuspay/paymentcallback"
            };
        }

        private string GenerateCartString(List<TemporaryOrderItem> items)
        {
            return string.Join(", ", items.Select(item => $"{item.ProductName} x {item.Quantity}"));
        }

        private string GenerateCorvusPaySignature(Dictionary<string, string> parameters)
        {
            var secretKey = _configuration["CorvusPaySettings:SecretKey"] ?? "TEST_SECRET";
            var dataToSign = string.Join("", new[]
            {
                parameters["version"],
                parameters["store_id"],
                parameters["order_number"],
                parameters["amount"],
                parameters["currency"],
                secretKey
            });

            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(dataToSign));
                return Convert.ToHexString(hash).ToLower();
            }
        }

        private bool VerifyCorvusPaySignature(Dictionary<string, string> formData)
        {
            var receivedSignature = formData.GetValueOrDefault("signature", "");
            var secretKey = _configuration["CorvusPaySettings:SecretKey"] ?? "TEST_SECRET";

            var dataToVerify = string.Join("", new[]
            {
                formData.GetValueOrDefault("version", ""),
                formData.GetValueOrDefault("store_id", ""),
                formData.GetValueOrDefault("order_number", ""),
                formData.GetValueOrDefault("amount", ""),
                formData.GetValueOrDefault("currency", ""),
                formData.GetValueOrDefault("approval_code", ""),
                secretKey
            });

            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(dataToVerify));
                var calculatedSignature = Convert.ToHexString(hash).ToLower();
                return calculatedSignature.Equals(receivedSignature, StringComparison.OrdinalIgnoreCase);
            }
        }

        private async Task<Order> CreateActualOrderFromTempAsync(string tempOrderId, string transactionId, string paymentReference)
        {
            var tempOrder = await GetTemporaryOrderDataAsync(tempOrderId);
            if (tempOrder == null) return null;

            var order = new Order
            {
                CustomerName = tempOrder.CustomerName,
                CustomerEmail = tempOrder.CustomerEmail,
                ShippingCity = tempOrder.ShippingCity,
                ShippingAddress = tempOrder.ShippingAddress,
                ShippingPostalCode = tempOrder.ShippingPostalCode,
                PhoneNumber = tempOrder.PhoneNumber,
                TransportFee = (int)tempOrder.TransportFee,
                OrderDate = DateTime.Now,
                ShipingCountry = tempOrder.ShipingCountry,
                PaymentType = "CORVUSPAY",
                CreatedById = tempOrder.UserId,
                TotalPrice = tempOrder.TotalAmount - tempOrder.TransportFee,
                TransactionId = transactionId,
                PaymentReference = paymentReference,
                OrderItems = tempOrder.CartItems.Select(item => new OrderItem
                {
                    ProductCode = item.ProductCode,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Size = int.Parse(item.SelectedSize),
                    ImagePath = item.ImagePath,
                    GTN = item.GTN
                }).ToList()
            };

            _orderService.Insert(order);

            // Add ERP records
            foreach (var item in tempOrder.CartItems)
            {
                var ERP = new ErpTemp
                {
                    ErpStatus = 0,
                    ArtikullEmri = item.ProductName,
                    PaymentMethod = "CORVUSPAY",
                    SasiaPaketim = item.Quantity,
                    DokumentID = order.OrderId,
                    KohaRegjistrimit = DateTime.Now,
                    CountryCode = "0",
                    Cmimi_me_TVSH = (double)item.Price,
                    ClientPhoneNr = order.PhoneNumber,
                    ClientAddress = $"{order.ShippingAddress} {order.ShippingCity} {order.ShipingCountry} {order.ShippingPostalCode}",
                    ClientName = order.CustomerName,
                    Kodi_Shitjes = "2-1A1",
                    ArtikullNjesia = "PALË",
                    DataModifikim = DateTime.Now,
                    ProductCode = item.ProductCode,
                    ArtikullBarcode = item.GTN
                };
                _erpTempService.Insert(ERP);
            }

            // Send emails
            await SendOrderEmailsAsync(order);

            return order;
        }

        private async Task SendOrderEmailsAsync(Order order)
        {
            // Send customer confirmation email
            if (!string.IsNullOrEmpty(order.CustomerEmail))
            {
                var msgReq = new EmailViewModel();
                msgReq.EmailTo = order.CustomerEmail;
                msgReq.Subject = "Potvrda narudžbe - NALLAN.HR";
                msgReq.Body = CroatianEmailTemplates.OrderConfirmationTemplate(order);

                bool emailToClient = _emailService.SentEmail(msgReq);
                CheckEmail(emailToClient, msgReq);
            }

            // Send internal notification email
            var confirmOrder = new EmailViewModel();
            confirmOrder.EmailTo = "info@nallan.hr";
            confirmOrder.Subject = "Nova narudžba - NALLAN.HR";
            confirmOrder.Body = CroatianEmailTemplates.InternalOrderNotificationTemplate(order);

            bool emailToNallan = _emailService.SentEmail(confirmOrder);
            CheckEmail(emailToNallan, confirmOrder);
        }

        private void CheckEmail(bool emailIsSent, EmailViewModel modeli)
        {
            var sendEmail = new SendEmail
            {
                Body = modeli.Body,
                Subject = modeli.Subject,
                Date = DateTime.Now,
                EmailTo = modeli.EmailTo,
                IsSended = emailIsSent,
                Queue = !emailIsSent,
                SendedFromSystem = true
            };
            _emailsService.Insert(sendEmail);
        }

        private async Task CleanupTemporaryOrderDataAsync(string tempOrderId)
        {
            var cacheKey = $"temp_order_{tempOrderId}";
            _cache.Remove(cacheKey);
        }

        // Model classes
        public class CheckoutFormModel
        {
            public string CustomerName { get; set; } = "";
            public string CustomerEmail { get; set; } = "";
            public string PhoneNumber { get; set; } = "";
            public string ShippingCity { get; set; } = "";
            public string ShippingAddress { get; set; } = "";
            public string ShippingPostalCode { get; set; } = "";
            public string ShipingCountry { get; set; } = "";
            public string PaymentType { get; set; } = "";
            public decimal TransportFee { get; set; }
            public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        }

        public class TemporaryOrderData
        {
            public string TempOrderId { get; set; } = "";
            public string UserId { get; set; } = "";
            public string CustomerName { get; set; } = "";
            public string CustomerEmail { get; set; } = "";
            public string PhoneNumber { get; set; } = "";
            public string ShippingCity { get; set; } = "";
            public string ShippingAddress { get; set; } = "";
            public string ShippingPostalCode { get; set; } = "";
            public string ShipingCountry { get; set; } = "";
            public decimal TransportFee { get; set; }
            public decimal TotalAmount { get; set; }
            public List<TemporaryOrderItem> CartItems { get; set; } = new();
            public DateTime CreatedAt { get; set; }
            public DateTime ExpiresAt { get; set; }
        }

        public class TemporaryOrderItem
        {
            public string ProductCode { get; set; } = "";
            public string ProductName { get; set; } = "";
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string SelectedSize { get; set; } = "";
            public string ImagePath { get; set; } = "";
            public string GTN { get; set; } = "";
        }

        public class CartItem
        {
            public string ProductId { get; set; } = "";
            public string ProductCode { get; set; } = "";
            public string ProductName { get; set; } = "";
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string SelectedSize { get; set; } = "";
            public string ImagePath { get; set; } = "";
            public string GTN { get; set; } = "";
        }

       
    }
}