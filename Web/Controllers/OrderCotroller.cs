using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Orders;
using Services;
using System.Collections.Generic;
using Web.Models;
using System;
using Web.Extensions;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using SimpleEmailApp.Services.EmailService;
using Web.Models.EmailConfig;
using Services.Emails;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.TEBPayments;
using System.Web;
using Web.Models.TebBank;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using Services.ProductServ;

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
        private readonly IApiServices _apiServices;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IProductService productService, IOrderService orderService, IMapper mapper,
            IErpTempService erpTempService, IEmailService emailService, IEmailsService emailsService,
            IHashService hashService, IOrderItemService orderItemService, IConfiguration configuration,
            IApiServices apiServices, ILogger<OrderController> logger)
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
            _apiServices = apiServices;
            _logger = logger;
        }

        public void CheckEmail(bool emailIsSent, EmailViewModel modeli)
        {
            try
            {
                var sendEmail = new SendEmail
                {
                    Body = modeli.Body,
                    Subject = modeli.Subject,
                    Date = DateTime.UtcNow,
                    EmailTo = modeli.EmailTo,
                    IsSended = emailIsSent,
                    Queue = !emailIsSent,
                    SendedFromSystem = true
                };

                _emailsService.Insert(sendEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging email status for {Email}", modeli.EmailTo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder(CheckoutViewModel model)
        {
            try
            {
                // 1. SERVER-SIDE INPUT VALIDATION
                var validationErrors = ValidateOrderInput(model);
                if (validationErrors.Any())
                {
                    return Json(new { success = false, message = string.Join(", ", validationErrors) });
                }

                // 2. GET CART FROM SESSION (Not from form - prevents tampering)
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
                if (!cart.Any())
                {
                    return Json(new { success = false, message = "Cart is empty!" });
                }

                // 3. VALIDATE CART ITEMS (Ensure they still exist and prices are correct)
                var validatedCart = await ValidateCartItems(cart);
                if (!validatedCart.IsValid)
                {
                    return Json(new { success = false, message = validatedCart.ErrorMessage });
                }

                // 4. CALCULATE PRICES SERVER-SIDE (Never trust client calculations)
                var transportFee = CalculateTransportFee(model.ShipingCountry);
                var totalPrice = validatedCart.Items.Sum(item => item.Price * item.Quantity);

                // 5. SANITIZE ALL INPUTS
                var sanitizedOrder = new Order
                {
                    CustomerName = SanitizeInput(model.CustomerName, 100),
                    CustomerEmail = SanitizeEmail(model.CustomerEmail),
                    ShippingCity = SanitizeInput(model.ShippingCity, 50),
                    ShippingAddress = SanitizeInput(model.ShippingAddress, 200),
                    ShippingPostalCode = SanitizeInput(model.ShippingPostalCode, 20),
                    PhoneNumber = SanitizePhoneNumber(model.PhoneNumber),
                    TransportFee = Convert.ToInt16(transportFee), // Server-calculated only
                    OrderDate = DateTime.UtcNow, // Use UTC
                    ShipingCountry = ValidateCountry(model.ShipingCountry),
                    PaymentType = ValidatePaymentType(model.PaymentType),
                    CreatedById = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier)?.Value : null,
                    TotalPrice = totalPrice, // Server-calculated only
                    OrderItems = validatedCart.Items.Select(item => new OrderItem
                    {
                        ProductCode = item.ProductCode,
                        ProductName = SanitizeInput(item.ProductName, 100),
                        Price = item.Price, // From validated cart
                        Quantity = Math.Max(1, Math.Min(item.Quantity, 10)), // Limit quantity
                        Size = ValidateSize(item.SelectedSize),
                        ImagePath = item.ImagePath,
                        GTN = item.GTN
                    }).ToList()
                };

                // 6. TRANSACTION WITH PROPER ERROR HANDLING
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    _orderService.Insert(sanitizedOrder);

                    // Create ERP entries with sanitized data
                    foreach (var item in validatedCart.Items)
                    {
                        var erpEntry = new ErpTemp
                        {
                            ErpStatus = 0,
                            ArtikullEmri = SanitizeInput(item.ProductName, 100),
                            PaymentMethod = "CASH",
                            SasiaPaketim = Math.Max(1, Math.Min(item.Quantity, 10)),
                            DokumentID = sanitizedOrder.OrderId,
                            KohaRegjistrimit = DateTime.UtcNow,
                            CountryCode = "0",
                            Cmimi_me_TVSH = (double)item.Price,
                            ClientPhoneNr = sanitizedOrder.PhoneNumber,
                            ClientAddress = $"{sanitizedOrder.ShippingAddress} {sanitizedOrder.ShippingCity} {sanitizedOrder.ShipingCountry} {sanitizedOrder.ShippingPostalCode}",
                            ClientName = sanitizedOrder.CustomerName,
                            Kodi_Shitjes = "2-1A1",
                            ArtikullNjesia = "PALË",
                            DataModifikim = DateTime.UtcNow,
                            ProductCode = item.ProductCode,
                            ArtikullBarcode = item.GTN
                        };
                        _erpTempService.Insert(erpEntry);
                    }

                    // Send emails (with proper error handling)
                    await SendOrderEmails(sanitizedOrder);

                    scope.Complete();
                    HttpContext.Session.Remove("Cart");

                    return Json(new { success = true, orderId = sanitizedOrder.OrderId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order for {Email}", model.CustomerEmail);
                return Json(new { success = false, message = "Order processing failed. Please try again." });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CreateBankOrder(CheckoutViewModel model)
        {
            try
            {
                // Same validation as CreateOrder
                var validationErrors = ValidateOrderInput(model);
                if (validationErrors.Any())
                {
                    return Json(new { success = false, message = string.Join(", ", validationErrors) });
                }

                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
                if (!cart.Any())
                {
                    return Json(new { success = false, message = "Cart is empty!" });
                }

                var validatedCart = await ValidateCartItems(cart);
                if (!validatedCart.IsValid)
                {
                    return Json(new { success = false, message = validatedCart.ErrorMessage });
                }

                var transportFee = CalculateTransportFee(model.ShipingCountry);
                var totalPrice = validatedCart.Items.Sum(item => item.Price * item.Quantity);

                // Store order data in session for later use after payment confirmation
                var orderData = new Order
                {
                    CustomerName = SanitizeInput(model.CustomerName, 100),
                    CustomerEmail = SanitizeEmail(model.CustomerEmail),
                    ShippingCity = SanitizeInput(model.ShippingCity, 50),
                    ShippingAddress = SanitizeInput(model.ShippingAddress, 200),
                    ShippingPostalCode = SanitizeInput(model.ShippingPostalCode, 20),
                    PhoneNumber = SanitizePhoneNumber(model.PhoneNumber),
                    TransportFee = Convert.ToInt16(transportFee),
                    OrderDate = DateTime.UtcNow,
                    ShipingCountry = ValidateCountry(model.ShipingCountry),
                    PaymentType = "BANK",
                    CreatedById = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier)?.Value : null,
                    TotalPrice = totalPrice,
                    OrderItems = validatedCart.Items.Select(item => new OrderItem
                    {
                        ProductCode = item.ProductCode,
                        ProductName = SanitizeInput(item.ProductName, 100),
                        Price = item.Price,
                        Quantity = Math.Max(1, Math.Min(item.Quantity, 10)),
                        Size = ValidateSize(item.SelectedSize),
                        ImagePath = item.ImagePath,
                        GTN = item.GTN
                    }).ToList()
                };

                HttpContext.Session.SetObjectAsJson("PendingOrder", orderData);
                HttpContext.Session.SetObjectAsJson("PendingCart", validatedCart.Items);

                var tempOrderId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("TempOrderId", tempOrderId);

                return Json(new { success = true, orderId = tempOrderId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating bank order for {Email}", model.CustomerEmail);
                return Json(new { success = false, message = "Order processing failed. Please try again." });
            }
        }

        [AllowAnonymous]
        public IActionResult BankPayment(string OrderId)
        {
            var pendingOrder = HttpContext.Session.GetObjectFromJson<Order>("PendingOrder");
            if (pendingOrder == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var storeK = Environment.GetEnvironmentVariable("TEBBANK_STORE_KEY");
            var clientK = Environment.GetEnvironmentVariable("TEBBANK_CLIENT_ID");

            Random rand = new Random();
            string randomNumber = string.Empty;

            for (int i = 0; i < 20; i++)
            {
                randomNumber += rand.Next(0, 10);
            }

            var model = new BankRequestVM
            {
                ClientId = clientK,
                StoreType = "3d_pay_hosting",
                TranType = "Auth",
                Amount = (pendingOrder.TotalPrice + pendingOrder.TransportFee),
                Currency = "978",
                OkUrl = "https://nallan.eu/hr/Order/BankResponse",
                FailUrl = "https://nallan.eu/hr/Order/BankResponse",
                CallBack = "https://www.nallan.eu/hr",
                Language = "hr",
                RandomValue = randomNumber.ToString(),
                hashAlgorithm = "ver3",
                refreshtime = "5",
                installmentonHPP = "Yes",
                billToName = pendingOrder.CustomerName,
                billToCompany = "NALLAN",
                OrderId = OrderId
            };

            var parameters = new Dictionary<string, string>
            {
                { "clientId", model.ClientId },
                { "amount", model.Amount.ToString() },
                { "okurl", model.OkUrl },
                { "failUrl", model.FailUrl },
                { "TranType", model.TranType },
                {"installmentHPP", model.installmentonHPP },
                { "callbackUrl", model.CallBack },
                { "currency", model.Currency },
                { "rnd", model.RandomValue },
                { "storetype", model.StoreType },
                {"hashAlgorithm", model.hashAlgorithm },
                { "lang", model.Language },
                {"BillToName", model.billToName },
                {"billToCompany", model.billToCompany },
                {"refreshTime", model.refreshtime },
                {"oid", model.OrderId }
            };

            var hash = _hashService.GenerateHashV3(storeK, parameters);
            model.Hash = hash;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> BankResponse()
        {
            try
            {
                var mdStatus = Request.Form["mdStatus"];
                var tempOrderId = Request.Form["oid"];
                var res = Request.Form["Response"];
                var prc = Request.Form["ProcReturnCode"];
                var ErrorDesc = Request.Form["ErrMsg"];

                var model = new PaymentResponseViewModel
                {
                    MdStatus = mdStatus,
                    Response = res
                };

                if (mdStatus == "1" || mdStatus == "2" || mdStatus == "3" || mdStatus == "4")
                {
                    if (prc == "00" || res == "Approved")
                    {
                        model.Response = "Pagesa u krye me sukses";

                        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
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
                                    ArtikullEmri = SanitizeInput(item.ProductName, 100),
                                    PaymentMethod = "BANK",
                                    SasiaPaketim = Math.Max(1, Math.Min(item.Quantity, 10)),
                                    DokumentID = pendingOrder.OrderId,
                                    KohaRegjistrimit = DateTime.UtcNow,
                                    CountryCode = "0",
                                    Cmimi_me_TVSH = (double)item.Price,
                                    ClientPhoneNr = pendingOrder.PhoneNumber,
                                    ClientAddress = $"{pendingOrder.ShippingAddress} {pendingOrder.ShippingCity} {pendingOrder.ShipingCountry} {pendingOrder.ShippingPostalCode}",
                                    ClientName = pendingOrder.CustomerName,
                                    Kodi_Shitjes = "2-1A1",
                                    ArtikullNjesia = "PALË",
                                    DataModifikim = DateTime.UtcNow,
                                    ProductCode = item.ProductCode,
                                    ArtikullBarcode = item.GTN
                                };
                                _erpTempService.Insert(ERP);
                            }

                            await SendOrderEmails(pendingOrder);

                            scope.Complete();

                            // Clear session
                            HttpContext.Session.Remove("PendingOrder");
                            HttpContext.Session.Remove("PendingCart");
                            HttpContext.Session.Remove("TempOrderId");

                            return RedirectToAction("OrderConfirmation", new { OrderId = pendingOrder.OrderId });
                        }
                    }
                    else
                    {
                        var failVM = new FailOrderVM
                        {
                            ErrorCode = prc,
                            ErrorDescription = ErrorDesc
                        };
                        return RedirectToAction("OrderFailed", failVM);
                    }
                }
                else
                {
                    var failVM = new FailOrderVM
                    {
                        ErrorCode = prc,
                        ErrorDescription = ErrorDesc
                    };
                    return RedirectToAction("OrderFailed", failVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing bank response");
                var failVM = new FailOrderVM
                {
                    ErrorCode = "500",
                    ErrorDescription = "Payment processing error"
                };
                return RedirectToAction("OrderFailed", failVM);
            }
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

        // VALIDATION HELPER METHODS
        private List<string> ValidateOrderInput(CheckoutViewModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.CustomerName) || model.CustomerName.Length > 100)
                errors.Add("Invalid customer name");

            if (string.IsNullOrWhiteSpace(model.CustomerEmail) || !IsValidEmail(model.CustomerEmail))
                errors.Add("Invalid email address");

            if (string.IsNullOrWhiteSpace(model.PhoneNumber) || model.PhoneNumber.Length > 20)
                errors.Add("Invalid phone number");

            if (string.IsNullOrWhiteSpace(model.ShippingAddress) || model.ShippingAddress.Length > 200)
                errors.Add("Invalid address");

            if (string.IsNullOrWhiteSpace(model.ShippingCity) || model.ShippingCity.Length > 50)
                errors.Add("Invalid city");

            if (model.ShipingCountry != "Hrvatska")
                errors.Add("Invalid country");

            if (model.PaymentType != "CASH" && model.PaymentType != "BANK")
                errors.Add("Invalid payment method");

            return errors;
        }

        private async Task<(bool IsValid, List<CartItem> Items, string ErrorMessage)> ValidateCartItems(List<CartItem> cart)
        {
            var validatedItems = new List<CartItem>();

            foreach (var item in cart)
            {
                try
                {
                    var product = await _apiServices.GetByIdAsync(item.ProductId);
                    if (product == null)
                    {
                        return (false, null, $"Product {item.ProductName} no longer exists");
                    }

                    if (product.Price != item.Price)
                    {
                        return (false, null, $"Price changed for {item.ProductName}");
                    }

                    validatedItems.Add(new CartItem
                    {
                        ProductId = item.ProductId,
                        ProductName = product.Title,
                        ProductCode = item.ProductCode,
                        Price = product.Price,
                        Quantity = Math.Max(1, Math.Min(item.Quantity, 10)),
                        SelectedSize = item.SelectedSize,
                        ImagePath = product.ImageUrls?.FirstOrDefault(),
                        GTN = product.GTIN
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error validating cart item {ProductId}", item.ProductId);
                    return (false, null, $"Error validating product {item.ProductName}");
                }
            }

            return (true, validatedItems, null);
        }

        private decimal CalculateTransportFee(string country)
        {
            return country switch
            {
                "Hrvatska" => 5m,
                _ => 0m
            };
        }

        private string ValidateCountry(string country)
        {
            return country == "Hrvatska" ? "Hrvatska" : throw new ArgumentException("Invalid country");
        }

        private string ValidatePaymentType(string paymentType)
        {
            return paymentType switch
            {
                "CASH" => "CASH",
                "BANK" => "BANK",
                _ => throw new ArgumentException("Invalid payment type")
            };
        }

        private int ValidateSize(string size)
        {
            if (int.TryParse(size, out int sizeInt) && sizeInt >= 35 && sizeInt <= 50)
                return sizeInt;
            throw new ArgumentException("Invalid size");
        }

        private string SanitizeInput(string input, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return HttpUtility.HtmlEncode(input.Trim().Substring(0, Math.Min(input.Trim().Length, maxLength)));
        }

        private string SanitizeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                throw new ArgumentException("Invalid email");

            return email.Trim().ToLowerInvariant();
        }

        private string SanitizePhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            var cleaned = new string(phone.Where(char.IsDigit).ToArray());
            return cleaned.Substring(0, Math.Min(cleaned.Length, 15));
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Length <= 254;
            }
            catch
            {
                return false;
            }
        }

        private async Task SendOrderEmails(Order order)
        {
            try
            {
                if (!string.IsNullOrEmpty(order.CustomerEmail))
                {
                    var msgReq = new EmailViewModel
                    {
                        EmailTo = order.CustomerEmail,
                        Subject = "Potvrda narudžbe na NALLAN.EU",
                        Body = GenerateCustomerEmailBody(order)
                    };

                    bool emailToClient = _emailService.SentEmail(msgReq);
                    CheckEmail(emailToClient, msgReq);
                }

                var confirmOrder = new EmailViewModel
                {
                    EmailTo = "info@nallan.eu",
                    Subject = "Nova narudžba na Nallan",
                    Body = GenerateAdminEmailBody(order)
                };

                bool emailToNallan = _emailService.SentEmail(confirmOrder);
                CheckEmail(emailToNallan, confirmOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending order emails for order {OrderId}", order.OrderId);
            }
        }

        private string GenerateCustomerEmailBody(Order order)
        {
            return $@"
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; color: #333; background-color: #f8f8f8; margin: 0; padding: 0; }}
        .container {{ width: 100%; padding: 20px; box-sizing: border-box; }}
        .order-details {{ background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); margin-bottom: 20px; }}
        .order-details h2 {{ color: #4CAF50; font-size: 24px; }}
        .order-table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }}
        .order-table th, .order-table td {{ padding: 10px; text-align: left; border: 1px solid #ddd; }}
        .order-table th {{ background-color: #f4f4f4; color: #333; }}
        .order-summary {{ margin-top: 20px; font-size: 16px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='order-details'>
            <h2>{HttpUtility.HtmlEncode(order.CustomerName)}</h2>
            <h2>Hvala što ste odabrali NALLAN za svoju kupovinu, vaša narudžba će uskoro biti poslana.</h2>
        </div>
        <h3>Detalji narudžbe:</h3>
        <table class='order-table'>
            <thead>
                <tr><th>Proizvod</th><th>Kod</th><th>Cijena</th><th>Količina</th><th>Ukupno</th></tr>
            </thead>
            <tbody>
                {string.Join("", order.OrderItems.Select(item => $@"
                    <tr>
                        <td>{HttpUtility.HtmlEncode(item.ProductName)}</td>
                        <td>{HttpUtility.HtmlEncode(item.ProductCode)}</td>
                        <td>{item.Price} €</td>
                        <td>{item.Quantity}</td>
                        <td>{item.Price * item.Quantity} €</td>
                    </tr>
                "))}
            </tbody>
        </table>
        <div class='order-summary'>
            <p><strong>Ukupna suma s transportom: </strong>{order.TotalPrice + order.TransportFee} €</p>
        </div>
    </div>
</body>
</html>";
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
        private string GenerateAdminEmailBody(Order order)
        {
            return $@"
<html>
<head>
   <style>
       body {{ 
           font-family: Arial, sans-serif; 
           color: #333; 
           background-color: #f8f8f8; 
           margin: 0; 
           padding: 0; 
       }}
       .container {{ 
           width: 100%; 
           padding: 20px; 
           box-sizing: border-box; 
       }}
       .order-details {{ 
           background-color: #ffffff; 
           padding: 20px; 
           border-radius: 8px; 
           box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
           margin-bottom: 20px; 
       }}
       .order-details h2 {{ 
           color: #4CAF50; 
           font-size: 24px; 
       }}
       .order-details p {{ 
           font-size: 16px; 
           line-height: 1.6; 
           margin: 8px 0; 
       }}
       .order-table {{ 
           width: 100%; 
           border-collapse: collapse; 
           margin-top: 20px; 
       }}
       .order-table th, .order-table td {{ 
           padding: 10px; 
           text-align: left; 
           border: 1px solid #ddd; 
       }}
       .order-table th {{ 
           background-color: #f4f4f4; 
           color: #333; 
       }}
       .order-summary {{ 
           margin-top: 20px; 
           font-size: 16px; 
       }}
       .order-summary strong {{ 
           color: #333; 
       }}
   </style>
</head>
<body>
   <div class='container'>
       <div class='order-details'>
           <h2>Nova narudžba</h2>
           <p><strong>Ime klijenta:</strong> {HttpUtility.HtmlEncode(order.CustomerName)}</p>
           <p><strong>Broj telefona:</strong> {HttpUtility.HtmlEncode(order.PhoneNumber)}</p>
           <p><strong>Email:</strong> {HttpUtility.HtmlEncode(order.CustomerEmail)}</p>
           <p><strong>Adresa:</strong> {HttpUtility.HtmlEncode(order.ShippingAddress)}</p>
           <p><strong>Grad:</strong> {HttpUtility.HtmlEncode(order.ShippingCity)}</p>
           <p><strong>Država:</strong> {HttpUtility.HtmlEncode(order.ShipingCountry)}</p>
           <p><strong>Poštanski broj:</strong> {HttpUtility.HtmlEncode(order.ShippingPostalCode)}</p>
           <p><strong>Način plaćanja:</strong> {HttpUtility.HtmlEncode(order.PaymentType)}</p>
           <p><strong>Transport:</strong> {order.TransportFee} €</p>
           <p><strong>Datum narudžbe:</strong> {order.OrderDate:dd/MM/yyyy HH:mm}</p>
       </div>

       <h3>Detalji narudžbe:</h3>
       <table class='order-table'>
           <thead>
               <tr>
                   <th>Proizvod</th>
                   <th>Kod</th>
                   <th>Cijena</th>
                   <th>Količina</th>
                   <th>Ukupno</th>
               </tr>
           </thead>
           <tbody>
               {string.Join("", order.OrderItems.Select(item => $@"
                   <tr>
                       <td>{HttpUtility.HtmlEncode(item.ProductName)}</td>
                       <td>{HttpUtility.HtmlEncode(item.ProductCode)}</td>
                       <td>{item.Price} €</td>
                       <td>{item.Quantity}</td>
                       <td>{item.Price * item.Quantity} €</td>
                   </tr>
               "))}
           </tbody>
       </table>

       <div class='order-summary'>
           <p><strong>Ukupna suma s transportom: </strong>{order.TotalPrice + order.TransportFee} €</p>
       </div>
   </div>
</body>
</html>";
        }
    }
}