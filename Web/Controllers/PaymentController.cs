using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection;
using Services.TEBPayments;
using Web.Models;
using Web.Models.TebBank;
using System.Security;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Web.Models.Payment;
using Web.Models.Payments;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Services.Orders;
using Web.Extensions;

namespace Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IHashService _hashService;
        private readonly ILogger<PaymentController> _logger;
        private readonly TebBankSettings _tebBankSettings;
        private readonly ISecureCredentialsService _credentialsService;
        private readonly IPaymentSessionService _sessionService;
        private readonly IMemoryCache _cache;
        private readonly IOrderService _orderService;

        public PaymentController(
            IHashService hashService,
            ILogger<PaymentController> logger,
            IOptions<TebBankSettings> tebBankSettings,
            ISecureCredentialsService credentialsService,
            IPaymentSessionService sessionService,
            IDataProtectionProvider dataProtectionProvider,
            IMemoryCache cache,
            IOrderService orderService)
        {
            _hashService = hashService;
            _logger = logger;
            _tebBankSettings = tebBankSettings.Value;
            _credentialsService = credentialsService;
            _sessionService = sessionService;
            _cache = cache;
            _orderService = orderService;
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
                var transportFee = model.TransportFee;
                var totalAmount = cartTotal + transportFee;

                if (totalAmount <= 0)
                {
                    return Json(new { success = false, message = "Invalid order amount" });
                }

                var tempOrderId = $"ORD_{DateTime.UtcNow:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N")[..8]}";
                await StoreTemporaryOrderDataAsync(tempOrderId, model, cart, totalAmount);

                var session = await _sessionService.CreateSessionAsync(
                    tempOrderId,
                    totalAmount,
                    User.Identity.Name ?? "anonymous",
                    _tebBankSettings.SessionTimeoutMinutes);

                return Json(new
                {
                    success = true,
                    sessionToken = session.Token,
                    orderId = tempOrderId,
                    amount = totalAmount,
                    redirectUrl = Url.Action("BankPayment", "Payment", new { token = session.Token })
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initiating payment from checkout");
                return Json(new { success = false, message = "Payment initiation failed. Please try again." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> BankPayment(string token)
        {
            try
            {
                // Remove CSP restrictions
                Response.Headers.Remove("Content-Security-Policy");
                Response.Headers.Remove("X-Frame-Options");
                Response.Headers.Add("Content-Security-Policy",
                    "default-src * 'unsafe-inline' 'unsafe-eval' data: blob:; form-action *;");

                var session = await GetPaymentSessionAsync(token);
                if (session == null || session.IsExpired || !session.IsValid)
                {
                    return RedirectToAction("PaymentError", new { error = "Invalid or expired payment session" });
                }

                var tempOrder = await GetTemporaryOrderDataAsync(session.OrderId);
                if (tempOrder == null)
                {
                    return RedirectToAction("PaymentError", new { error = "Order data not found" });
                }

                var nonce = GenerateSecureNonce();
                var parameters = await CreatePaymentParametersAsync(session, tempOrder, nonce);

                using var credentials = await _credentialsService.GetCredentialsAsync();
                var clientId = SecureStringToString(credentials.ClientId);
                parameters["clientid"] = clientId;

                var hash = await _credentialsService.GenerateSecureHashAsync(parameters);

                var model = new BankRequestVM
                {
                    ClientId = clientId,
                    Amount = session.Amount,
                    OrderId = session.OrderId,
                    OkUrl = parameters["okurl"],
                    FailUrl = parameters["failurl"],
                    CallBack = parameters["callbackurl"],
                    TranType = parameters["trantype"],
                    RandomValue = parameters["rnd"],
                    Currency = parameters["currency"],
                    StoreType = parameters["storetype"],
                    hashAlgorithm = parameters["hashAlgorithm"],
                    Language = parameters["lang"],
                    billToName = parameters["BillToName"],
                    billToCompany = parameters["BillToCompany"],
                    refreshtime = parameters["refreshtime"],
                    installmentonHPP = parameters["installment"],
                    Hash = hash
                };

                return View("BankPayment", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error displaying bank payment page");
                return RedirectToAction("PaymentError", new { error = "Error loading payment page" });
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> PaymentCallback(string token)
        {
            try
            {
                var session = await GetPaymentSessionAsync(token);
                if (session == null || session.IsExpired)
                {
                    return BadRequest("Invalid payment session");
                }

                var formData = new Dictionary<string, string>();
                foreach (var key in Request.Form.Keys)
                {
                    formData[key] = Request.Form[key].ToString();
                }

                var mdStatus = formData.GetValueOrDefault("mdStatus", "");
                var response = formData.GetValueOrDefault("Response", "");
                var procReturnCode = formData.GetValueOrDefault("ProcReturnCode", "");
                var transId = formData.GetValueOrDefault("TransId", "");
                var hostRefNum = formData.GetValueOrDefault("HostRefNum", "");

                var successfulMdStatuses = new[] { "1", "2", "3", "4" };
                var isSuccess = successfulMdStatuses.Contains(mdStatus) &&
                              (procReturnCode == "00" || response.Equals("Approved", StringComparison.OrdinalIgnoreCase));

                if (isSuccess)
                {
                    var actualOrder = await CreateActualOrderFromTempAsync(session.OrderId, transId, hostRefNum);
                    if (actualOrder != null)
                    {
                        await CleanupTemporaryOrderDataAsync(session.OrderId);
                        await InvalidatePaymentSessionAsync(token);
                        return RedirectToAction("OrderConfirmation", "Order", new { OrderId = actualOrder.OrderId });
                    }
                }

                await InvalidatePaymentSessionAsync(token);
                return RedirectToAction("OrderFailed", "Order", new
                {
                    ErrorCode = procReturnCode,
                    ErrorDescription = formData.GetValueOrDefault("ErrMsg", "Payment failed")
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment callback");
                return RedirectToAction("PaymentError", new { error = "Payment processing failed" });
            }
        }

        private async Task<Dictionary<string, string>> CreatePaymentParametersAsync(PaymentSession session, TemporaryOrderData tempOrder, string nonce)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            return new Dictionary<string, string>
            {
                ["amount"] = session.Amount.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                ["oid"] = session.OrderId,
                ["okurl"] = $"{baseUrl}/sq/payment/paymentsuccess?token={session.Token}",
                ["failurl"] = $"{baseUrl}/sq/payment/paymentfailed?token={session.Token}",
                ["callbackurl"] = $"{baseUrl}/sq/payment/paymentcallback?token={session.Token}",
                ["trantype"] = "Auth",
                ["installment"] = "",
                ["rnd"] = nonce,
                ["currency"] = "978",
                ["storetype"] = "3d_pay_hosting",
                ["hashAlgorithm"] = "ver3",
                ["lang"] = "en",
                ["refreshtime"] = "10",
                ["BillToName"] = tempOrder.CustomerName ?? "",
                ["BillToCompany"] = ""
            };
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
                TransportFee = tempOrder.TransportFee,
                OrderDate = DateTime.Now,
                ShipingCountry = tempOrder.ShipingCountry,
                PaymentType = "BANK",
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
            return order;
        }

        private async Task StoreTemporaryOrderDataAsync(string tempOrderId, CheckoutFormModel model, List<CartItem> cart, decimal totalAmount)
        {
            var tempOrder = new TemporaryOrderData
            {
                TempOrderId = tempOrderId,
                UserId = User.Identity.IsAuthenticated ? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : null,
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                PhoneNumber = model.PhoneNumber,
                ShippingCity = model.ShippingCity,
                ShippingAddress = model.ShippingAddress,
                ShippingPostalCode = model.ShippingPostalCode,
                ShipingCountry = model.ShipingCountry,
                TransportFee = model.TransportFee,
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

        private async Task<PaymentSession> GetPaymentSessionAsync(string token)
        {
            return await _sessionService.GetSessionAsync(token);
        }

        private async Task InvalidatePaymentSessionAsync(string token)
        {
            await _sessionService.InvalidateSessionAsync(token);
        }

        private async Task CleanupTemporaryOrderDataAsync(string tempOrderId)
        {
            var cacheKey = $"temp_order_{tempOrderId}";
            _cache.Remove(cacheKey);
        }

        private string GenerateSecureNonce()
        {
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            var bytes = new byte[16];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes).Replace("+", "").Replace("/", "").Replace("=", "");
        }

        private string SecureStringToString(SecureString secureString)
        {
            if (secureString == null) return "";

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(ptr) ?? "";
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            }
        }

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
            public int TransportFee { get; set; }
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
            public int TransportFee { get; set; }
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