using AutoMapper;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services;
using Services.Emails;
using Services.Orders;
using Services.TEBPayments;
using SimpleEmailApp.Services.EmailService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Web.Extensions;
using Web.Filters;
using Web.Models;
using Web.Models.EmailConfig;
using Web.Models.EmailTemplates;
using Web.Models.TebBank;

namespace Web.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;
        private readonly IErpTempService _erpTempService;
        private readonly IEmailService _emailService;
        private readonly IEmailsService _emailsService;
        private readonly IHashService _hashService;
        private readonly IConfiguration _configuration;

        public OrderController(IProductService productService, IOrderService orderService, IMapper mapper, IErpTempService erpTempService, IEmailService emailService, IEmailsService emailsService, IHashService hashService, IOrderItemService orderItemService, IConfiguration configuration)
        {
            _productService = productService;
            _orderService = orderService;
            _mapper = mapper;
            _erpTempService = erpTempService;
            _emailService = emailService;
            _emailsService = emailsService;
            _hashService = hashService;
            _orderItemService = orderItemService;
            _configuration = configuration;
        }

        public void CheckEmail(bool emailIsSent, EmailViewModel modeli)
        {
            if (emailIsSent)
            {
                var sendEmail = new SendEmail
                {
                    Body = modeli.Body,
                    Subject = modeli.Subject,
                    Date = DateTime.Now,
                    EmailTo = modeli.EmailTo,
                    IsSended = true,
                    Queue = false,
                    SendedFromSystem = true
                };
                _emailsService.Insert(sendEmail);
            }
            else
            {
                var sendEmail = new SendEmail
                {
                    Body = modeli.Body,
                    Subject = modeli.Subject,
                    Date = DateTime.Now,
                    EmailTo = modeli.EmailTo,
                    IsSended = false,
                    Queue = true,
                    SendedFromSystem = true
                };
                _emailsService.Insert(sendEmail);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult CreateOrder(CheckoutViewModel model)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            if (!cart.Any())
            {
                return Json(new { success = false, message = "Cart is empty!" });
            }

            // Set transport fee for Croatia
            model.TransportFee = model.ShipingCountry == "Hrvatska" ? 4.5m : 4.5m;

            var order = new Order
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                ShippingCity = model.ShippingCity,
                ShippingAddress = model.ShippingAddress,
                ShippingPostalCode = model.ShippingPostalCode,
                PhoneNumber = model.PhoneNumber,
                TransportFee = (int)model.TransportFee,
                OrderDate = DateTime.Now,
                ShipingCountry = model.ShipingCountry,
                PaymentType = model.PaymentType,
                CreatedById = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier)?.Value : null,
                TotalPrice = cart.Sum(item => item.Price * item.Quantity),
                OrderItems = cart.Select(item => new OrderItem
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

            using (var scope = new TransactionScope())
            {
                try
                {
                    _orderService.Insert(order);
                    foreach (var item in cart)
                    {
                        var ERP = new ErpTemp
                        {
                            ErpStatus = 0,
                            ArtikullEmri = item.ProductName,
                            PaymentMethod = "CASH",
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

                    // Send customer confirmation email (Croatian)
                    if (!string.IsNullOrEmpty(order.CustomerEmail))
                    {
                        var msgReq = new EmailViewModel();
                        msgReq.EmailTo = order.CustomerEmail;
                        msgReq.Subject = "Potvrda narudžbe - NALLAN.HR";
                        msgReq.Body = CroatianEmailTemplates.OrderConfirmationTemplate(order);

                        bool emailToClient = _emailService.SentEmail(msgReq);
                        CheckEmail(emailToClient, msgReq);
                    }

                    // Send internal notification email (Croatian)
                    var confirmOrder = new EmailViewModel();
                    confirmOrder.EmailTo = "info@nallan.hr";
                    confirmOrder.Subject = "Nova narudžba - NALLAN.HR";
                    confirmOrder.Body = CroatianEmailTemplates.InternalOrderNotificationTemplate(order);

                    bool emailToNallan = _emailService.SentEmail(confirmOrder);
                    CheckEmail(emailToNallan, confirmOrder);

                    scope.Complete();
                    HttpContext.Session.Remove("Cart");

                    return Json(new { success = true, orderId = order.OrderId });
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return Json(new { success = false, msg = "Narudžba neuspješna" });
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult CreateBankOrder(CheckoutViewModel model)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            if (!cart.Any())
            {
                return Json(new { success = false, message = "Cart is empty!" });
            }

            model.TransportFee = model.ShipingCountry == "Hrvatska" ? 4.5m : 4.5m;

            var orderData = new Order
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                ShippingCity = model.ShippingCity,
                ShippingAddress = model.ShippingAddress,
                ShippingPostalCode = model.ShippingPostalCode,
                PhoneNumber = model.PhoneNumber,
                TransportFee = (int)model.TransportFee,
                OrderDate = DateTime.Now,
                ShipingCountry = model.ShipingCountry,
                PaymentType = "CORVUSPAY",
                CreatedById = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier)?.Value : null,
                TotalPrice = cart.Sum(item => item.Price * item.Quantity),
                OrderItems = cart.Select(item => new OrderItem
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

            HttpContext.Session.SetObjectAsJson("PendingOrder", orderData);
            HttpContext.Session.SetObjectAsJson("PendingCart", cart);

            var tempOrderId = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("TempOrderId", tempOrderId);

            return Json(new { success = true, orderId = tempOrderId });
        }

        [AllowAnonymous]
        public IActionResult BankPayment(string OrderId)
        {
            var pendingOrder = HttpContext.Session.GetObjectFromJson<Order>("PendingOrder");
            if (pendingOrder == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Redirect to CorvusPay instead of TEB Bank for Croatia
            return RedirectToAction("CorvusPayment", "CorvusPay", new { orderId = OrderId });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult BankResponse()
        {
            var mdStatus = Request.Form["mdStatus"];
            int orderIdd = int.Parse(Request.Form["oid"]);
            var res = Request.Form["Response"];
            var prc = Request.Form["ProcReturnCode"];
            var ErrorDesc = Request.Form["ErrMsg"];
            var model = new PaymentResponseViewModel();
            model.MdStatus = mdStatus;
            model.Response = res;

            if (mdStatus == "1" || mdStatus == "2" || mdStatus == "3" || mdStatus == "4")
            {
                if (prc == "00" || res == "Approved")
                {
                    model.Response = "Plaćanje uspješno";

                    using (var scope = new TransactionScope())
                    {
                        try
                        {
                            var pendingOrder = HttpContext.Session.GetObjectFromJson<Order>("PendingOrder");
                            var pendingCart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("PendingCart");

                            if (pendingOrder == null || pendingCart == null)
                            {
                                return Json(new { success = false, msg = "Session expired" });
                            }

                            _orderService.Insert(pendingOrder);

                            foreach (var item in pendingCart)
                            {
                                var ERP = new ErpTemp
                                {
                                    ErpStatus = 0,
                                    ArtikullEmri = item.ProductName,
                                    PaymentMethod = "CORVUSPAY",
                                    SasiaPaketim = item.Quantity,
                                    DokumentID = pendingOrder.OrderId,
                                    KohaRegjistrimit = DateTime.Now,
                                    CountryCode = "0",
                                    Cmimi_me_TVSH = (double)item.Price,
                                    ClientPhoneNr = pendingOrder.PhoneNumber,
                                    ClientAddress = $"{pendingOrder.ShippingAddress} {pendingOrder.ShippingCity} {pendingOrder.ShipingCountry} {pendingOrder.ShippingPostalCode}",
                                    ClientName = pendingOrder.CustomerName,
                                    Kodi_Shitjes = "2-1A1",
                                    ArtikullNjesia = "PALË",
                                    DataModifikim = DateTime.Now,
                                    ProductCode = item.ProductCode,
                                    ArtikullBarcode = item.GTN
                                };
                                _erpTempService.Insert(ERP);
                            }

                            // Send customer confirmation email (Croatian)
                            if (!string.IsNullOrEmpty(pendingOrder.CustomerEmail))
                            {
                                var msgReq = new EmailViewModel();
                                msgReq.EmailTo = pendingOrder.CustomerEmail;
                                msgReq.Subject = "Potvrda narudžbe - NALLAN.HR";
                                msgReq.Body = CroatianEmailTemplates.OrderConfirmationTemplate(pendingOrder);

                                bool emailToClient = _emailService.SentEmail(msgReq);
                                CheckEmail(emailToClient, msgReq);
                            }

                            // Send internal notification email (Croatian)
                            var confirmOrder = new EmailViewModel();
                            confirmOrder.EmailTo = "info@nallan.hr";
                            confirmOrder.Subject = "Nova narudžba - NALLAN.HR";
                            confirmOrder.Body = CroatianEmailTemplates.InternalOrderNotificationTemplate(pendingOrder);

                            bool emailToNallan = _emailService.SentEmail(confirmOrder);
                            CheckEmail(emailToNallan, confirmOrder);

                            scope.Complete();
                            return RedirectToAction("OrderConfirmation", new { OrderId = pendingOrder.OrderId });
                        }
                        catch (Exception ex)
                        {
                            scope.Dispose();
                            return Json(new { success = false, msg = "Narudžba neuspješna" });
                        }
                    }
                }
                else if (prc == "99" || res == "Error")
                {
                    var failVM = new FailOrderVM();
                    failVM.ErrorCode = prc;
                    failVM.ErrorDescription = ErrorDesc;
                    var dbOrder = _orderService.GetById(orderIdd);
                    dbOrder.DeletedById = "46c63502-9987-44b8-aa1c-e2770aeb414d";
                    dbOrder.DeletedDate = DateTime.Now;
                    _orderService.Delete(dbOrder);
                    return RedirectToAction("OrderFailed", failVM);
                }
                else
                {
                    var failVM = new FailOrderVM();
                    failVM.ErrorCode = prc;
                    failVM.ErrorDescription = ErrorDesc;
                    var dbOrder = _orderService.GetById(orderIdd);
                    dbOrder.DeletedById = "46c63502-9987-44b8-aa1c-e2770aeb414d";
                    dbOrder.DeletedDate = DateTime.Now;
                    _orderService.Delete(dbOrder);
                    return RedirectToAction("OrderFailed", failVM);
                }
            }
            else
            {
                var failVM = new FailOrderVM();
                failVM.ErrorCode = prc;
                failVM.ErrorDescription = ErrorDesc;
                var dbOrder = _orderService.GetById(orderIdd);
                dbOrder.DeletedById = "46c63502-9987-44b8-aa1c-e2770aeb414d";
                dbOrder.DeletedDate = DateTime.Now;
                _orderService.Delete(dbOrder);
                return RedirectToAction("OrderFailed", failVM);
            }
        }

        private string ExtractRedirectUrl(string content)
        {
            if (content.Contains("redirectUrl"))
            {
                var start = content.IndexOf("redirectUrl") + 13;
                var end = content.IndexOf("\"", start);
                return content.Substring(start, end - start);
            }
            return null;
        }

        public IActionResult Index()
        {
            var model = new IndexOrdersViewModel();
            var db = _orderService.GetAll().OrderByDescending(o => o.CreatedDate);
            if (User.IsInRole("Client"))
            {
                db = _orderService.GetAllByUserId().OrderByDescending(o => o.CreatedDate);
            }
            model.Orders = _mapper.Map<List<OrdersViewModel>>(db);
            return View(model);
        }

        public IActionResult Order(int OrderId)
        {
            var db = _orderService.GetById(OrderId);
            var model = _mapper.Map<OrdersViewModel>(db);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult OrderConfirmation(int OrderId)
        {
            var db = _orderService.GetById(OrderId);
            var model = _mapper.Map<OrdersViewModel>(db);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult OrderFailed(FailOrderVM model)
        {
            return View(model);
        }

        // Add these methods to your existing OrderController class

        #region API Endpoints for n8n Integration

        [HttpPost]
        [Route("api/orders")]
        [ApiKeyAuth]
        public async Task<IActionResult> CreateOrderFromMessenger([FromBody] MessengerOrderRequest request)
        {
            try
            {
                // Validate required fields
                if (request == null || string.IsNullOrEmpty(request.ProductId) ||
                    string.IsNullOrEmpty(request.CustomerFirstName) ||
                    string.IsNullOrEmpty(request.CustomerPhone))
                {
                    return Json(new { success = false, message = "Required fields missing" });
                }

                // You'll need to get product details from your API service
                // This assumes you have access to _apiServices in OrderController
                // If not, you can inject IApiServices into this controller
                var product = await GetProductDetailsById(request.ProductId);
                if (product == null)
                {
                    return Json(new { success = false, message = "Product not found" });
                }

                // Create the order using your existing structure
                var order = new Order
                {
                    CustomerName = $"{request.CustomerFirstName} {request.CustomerLastName}".Trim(),
                    CustomerEmail = request.CustomerEmail ?? "",
                    ShippingCity = ExtractCityFromAddress(request.CustomerAddress),
                    ShippingAddress = request.CustomerAddress,
                    ShippingPostalCode = "", // Extract if needed
                    PhoneNumber = request.CustomerPhone,
                    TransportFee = 4, // Default transport fee
                    OrderDate = DateTime.Now,
                    ShipingCountry = "Kosovo", // Default or extract from address
                    PaymentType = "CASH", // Messenger orders are typically cash on delivery
                    CreatedById = null, // No user authentication for messenger orders
                    TotalPrice = request.TotalPrice > 0 ? request.TotalPrice : product.Price,
                    OrderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    ProductCode = request.ProductId,
                    ProductName = product.Name,
                    Price = request.TotalPrice > 0 ? request.TotalPrice : product.Price,
                    Quantity = 1, // Default quantity
                    Size = ExtractSizeFromNotes(request.Notes), // Extract size if provided
                    ImagePath = product.ImageUrl ?? "",
                    GTN = product.Barcode ?? request.ProductId
                }
            }
                };

                using (var scope = new TransactionScope())
                {
                    try
                    {
                        _orderService.Insert(order);

                        // Create ERP record
                        var erpRecord = new ErpTemp
                        {
                            ErpStatus = 0,
                            ArtikullEmri = product.Name,
                            PaymentMethod = "MESSENGER_CASH",
                            SasiaPaketim = 1,
                            DokumentID = order.OrderId,
                            KohaRegjistrimit = DateTime.Now,
                            CountryCode = "0",
                            Cmimi_me_TVSH = (double)(request.TotalPrice > 0 ? request.TotalPrice : product.Price),
                            ClientPhoneNr = order.PhoneNumber,
                            ClientAddress = order.ShippingAddress,
                            ClientName = order.CustomerName,
                            Kodi_Shitjes = "2-1A1",
                            ArtikullNjesia = "PALË",
                            DataModifikim = DateTime.Now,
                            ProductCode = request.ProductId,
                            ArtikullBarcode = product.Barcode ?? request.ProductId
                        };
                        _erpTempService.Insert(erpRecord);

                        // Send confirmation email if email is provided
                        if (!string.IsNullOrEmpty(order.CustomerEmail))
                        {
                            var msgReq = new EmailViewModel
                            {
                                EmailTo = order.CustomerEmail,
                                Subject = "Konfirmimi i porosisë - NALLAN.EU",
                                Body = CreateMessengerOrderEmailTemplate(order)
                            };

                            bool emailToClient = _emailService.SentEmail(msgReq);
                            CheckEmail(emailToClient, msgReq);
                        }

                        // Send internal notification
                        var internalNotification = new EmailViewModel
                        {
                            EmailTo = "info@nallan.eu",
                            Subject = $"Porosi e re nga Facebook Messenger - {order.CustomerName}",
                            Body = CreateInternalMessengerNotificationTemplate(order, request.Source, request.Notes)
                        };

                        bool emailToNallan = _emailService.SentEmail(internalNotification);
                        CheckEmail(emailToNallan, internalNotification);

                        scope.Complete();

                        return Json(new
                        {
                            success = true,
                            message = "Order created successfully",
                            orderId = order.OrderId,
                            orderNumber = order.OrderId
                        });
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        return Json(new { success = false, message = "Order creation failed: " + ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error processing order: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("api/orders/{orderId}")]
        [ApiKeyAuth]
        public IActionResult GetOrderStatus(int orderId)
        {
            try
            {
                var order = _orderService.GetById(orderId);
                if (order == null)
                {
                    return Json(new { success = false, message = "Order not found" });
                }

                return Json(new
                {
                    success = true,
                    order = new
                    {
                        orderId = order.OrderId,
                        customerName = order.CustomerName,
                        totalPrice = order.TotalPrice,
                        orderDate = order.OrderDate,
                        status = order.DeletedDate.HasValue ? "Cancelled" : "Active",
                        paymentType = order.PaymentType
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        #endregion

        #region Helper Methods for Messenger Orders

        private async Task<ProductDetails> GetProductDetailsById(string productId)
        {
            try
            {
                // If you don't have access to _apiServices in OrderController, 
                // you'll need to inject IApiServices or create a separate service
                // For now, I'll create a mock structure - replace with your actual API call

                // Example: var product = await _apiServices.GetByIdAsync(productId, "en");
                // For now, return a mock product - you should replace this with actual product lookup
                return new ProductDetails
                {
                    Id = productId,
                    Name = "Product " + productId,
                    Price = 29.99m,
                    ImageUrl = "",
                    Barcode = productId
                };
            }
            catch
            {
                return null;
            }
        }

        private string ExtractCityFromAddress(string address)
        {
            if (string.IsNullOrEmpty(address)) return "";

            // Simple city extraction - you can make this more sophisticated
            var parts = address.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return parts.LastOrDefault()?.Trim() ?? "";
        }

        private int ExtractSizeFromNotes(string notes)
        {
            if (string.IsNullOrEmpty(notes)) return 42; // Default size

            // Try to extract size from notes
            var sizePattern = @"\b(\d{2})\b";
            var match = System.Text.RegularExpressions.Regex.Match(notes, sizePattern);

            if (match.Success && int.TryParse(match.Value, out int size))
            {
                return size;
            }

            return 42; // Default size
        }

        private string CreateMessengerOrderEmailTemplate(Order order)
        {
            return $@"
        <h2>Konfirmimi i Porosisë</h2>
        <p>Përshëndetje {order.CustomerName},</p>
        <p>Porosia juaj është regjistruar me sukses!</p>
        
        <h3>Detajet e porosisë:</h3>
        <ul>
            <li><strong>Numri i porosisë:</strong> {order.OrderId}</li>
            <li><strong>Data:</strong> {order.OrderDate:dd/MM/yyyy HH:mm}</li>
            <li><strong>Çmimi total:</strong> €{order.TotalPrice:F2}</li>
            <li><strong>Adresa e dërgesës:</strong> {order.ShippingAddress}</li>
            <li><strong>Telefoni:</strong> {order.PhoneNumber}</li>
        </ul>
        
        <p>Do t'ju kontaktojmë së shpejti për të konfirmuar detajet e dërgesës.</p>
        <p>Faleminderit që zgjodhët NALLAN.EU!</p>
    ";
        }

        private string CreateInternalMessengerNotificationTemplate(Order order, string source, string notes)
        {
            var emailBody = $@"
        <h2>Porosi e Re nga Facebook Messenger</h2>
        
        <h3>Detajet e porosisë:</h3>
        <ul>
            <li><strong>ID e porosisë:</strong> {order.OrderId}</li>
            <li><strong>Klienti:</strong> {order.CustomerName}</li>
            <li><strong>Telefoni:</strong> {order.PhoneNumber}</li>
            <li><strong>Email:</strong> {order.CustomerEmail}</li>
            <li><strong>Adresa:</strong> {order.ShippingAddress}</li>
            <li><strong>Çmimi total:</strong> €{order.TotalPrice:F2}</li>
            <li><strong>Burimi:</strong> {source}</li>
            <li><strong>Data:</strong> {order.OrderDate:dd/MM/yyyy HH:mm}</li>
        </ul>
        
        <h3>Produktet:</h3>
        <ul>";

            foreach (var item in order.OrderItems)
            {
                emailBody += $"<li>{item.ProductName} - €{item.Price:F2} (Sasia: {item.Quantity})</li>";
            }

            emailBody += $@"
        </ul>
        
        {(!string.IsNullOrEmpty(notes) ? $"<p><strong>Shënime:</strong> {notes}</p>" : "")}
        
        <p>Kjo porosi është bërë përmes Facebook Messenger dhe duhet kontaktuar klienti për konfirmim.</p>";

            return emailBody;
        }

        #endregion

        // Data model for messenger order requests
        public class MessengerOrderRequest
        {
            public string ProductId { get; set; }
            public string CustomerFirstName { get; set; }
            public string CustomerLastName { get; set; }
            public string CustomerPhone { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerEmail { get; set; }
            public decimal TotalPrice { get; set; }
            public string Source { get; set; }
            public string Notes { get; set; }
        }

        // Helper class for product details
        public class ProductDetails
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public string Barcode { get; set; }
        }
    }
}