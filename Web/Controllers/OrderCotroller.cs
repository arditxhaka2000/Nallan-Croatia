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
                // Create a single SendEmail object since only one email is being sent
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

                // Insert the email record into the database
                _emailsService.Insert(sendEmail);
            }
            else
            {
                // Create a single SendEmail object for failed email
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

                // Insert the email record into the database
                _emailsService.Insert(sendEmail);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult CreateOrder(CheckoutViewModel model)
        {
            // Get the cart items from the session
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            if (!cart.Any())
            {
                return Json(new { success = false, message = "Cart is empty!" });
            }

            // Set the transport fee based on the shipping country
            switch (model.ShipingCountry)
            {
                case "Kosovë":
                    model.TransportFee = 2;
                    break;
                case "Shqipëri":
                    model.TransportFee = 5;
                    break;
                case "Maqedoni":
                    model.TransportFee = 5;
                    break;
                default:
                    model.TransportFee = 0;
                    break;
            }

            // Create a new order
            var order = new Order
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                ShippingCity = model.ShippingCity,
                ShippingAddress = model.ShippingAddress,
                ShippingPostalCode = model.ShippingPostalCode,
                PhoneNumber = model.PhoneNumber,
                TransportFee = model.TransportFee,
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
                    if (!string.IsNullOrEmpty(order.CustomerEmail))
                    {
                        var msgReq = new EmailViewModel();
                        msgReq.EmailTo = order.CustomerEmail;
                        msgReq.Subject = "Konfirmim i porosis suaj në NALLAN.EU";
                        msgReq.Body = @"
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f8f8f8;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }
        .order-details {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }
        .order-details h2 {
            color: #4CAF50;
            font-size: 24px;
        }
        .order-details p {
            font-size: 16px;
            line-height: 1.6;
            margin: 8px 0;
        }
        .order-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .order-table th, .order-table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }
        .order-table th {
            background-color: #f4f4f4;
            color: #333;
        }
        .order-summary {
            margin-top: 20px;
            font-size: 16px;
        }
        .order-summary strong {
            color: #333;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='order-details'>
            <h2>"+order.CustomerName + @"</h2>
            <h2>Falemnderit që zgjodhet NALLAN për blerjen tuaj, porosia juaj së shpejti do të dërgohet tek ju.</h2>
        </div>

        <h3>Detajet e Porosisë:</h3>
        <table class='order-table'>
            <thead>
                <tr>
                    <th>Produkti</th>
                    <th>Kodi</th>
                    <th>Çmimi</th>
                    <th>Sasia</th>
                    <th>Gjithsej</th>
                </tr>
            </thead>
            <tbody>
                " + string.Join("", order.OrderItems.Select(item => @"
                    <tr>
                        <td>" + item.ProductName + @"</td>
                        <td>" + item.ProductCode + @"</td>
                        <td>" + item.Price + @"</td>
                        <td>" + item.Quantity + @"</td>
                        <td>" + (item.Price * item.Quantity) + @"</td>
                    </tr>
                ")) + @"
            </tbody>
        </table>

        <div class='order-summary'>
            <p><strong>Shuma Totale me transport: </strong> " + (order.TotalPrice + order.TransportFee) + @"</p>
        </div>
    </div>
</body>
</html>";
                        bool emailToClient = _emailService.SentEmail(msgReq);
                        CheckEmail(emailToClient, msgReq);
                    }
                    var confirmOrder = new EmailViewModel();
                    confirmOrder.EmailTo = "info@nallan.eu";
                    confirmOrder.Subject = "Porosi e re ne Nallan";
                    confirmOrder.Body = @"
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f8f8f8;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }
        .order-details {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }
        .order-details h2 {
            color: #4CAF50;
            font-size: 24px;
        }
        .order-details p {
            font-size: 16px;
            line-height: 1.6;
            margin: 8px 0;
        }
        .order-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .order-table th, .order-table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }
        .order-table th {
            background-color: #f4f4f4;
            color: #333;
        }
        .order-summary {
            margin-top: 20px;
            font-size: 16px;
        }
        .order-summary strong {
            color: #333;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='order-details'>
            <h2>Porosi e Re</h2>
            <p><strong>Emri i Klientit:</strong> " + order.CustomerName + @"</p>
            <p><strong>Numri i Telefonit:</strong> " + order.PhoneNumber + @"</p>
            <p><strong>Email:</strong> " + order.CustomerEmail + @"</p>
            <p><strong>Adresa:</strong> " + order.ShippingAddress + @"</p>
            <p><strong>Qyteti:</strong> " + order.ShippingCity + @"</p>
            <p><strong>Shteti:</strong> " + order.ShipingCountry + @"</p>
            <p><strong>Kodi Postal:</strong> " + order.ShippingPostalCode + @"</p>
            <p><strong>Lloji i Pageses:</strong> " + order.PaymentType + @"</p>
            <p><strong>Tarifa e Transportit:</strong> " + order.TransportFee + @"</p>
            <p><strong>Data e Porosisë:</strong> " + order.OrderDate.ToString("dd/MM/yyyy HH:mm") + @"</p>
        </div>

        <h3>Detajet e Porosisë:</h3>
        <table class='order-table'>
            <thead>
                <tr>
                    <th>Produkti</th>
                    <th>Kodi/th>
                    <th>Çmimi</th>
                    <th>Sasia</th>
                    <th>Gjithsej</th>
                </tr>
            </thead>
            <tbody>
                " + string.Join("", order.OrderItems.Select(item => @"
                    <tr>
                        <td>" + item.ProductName + @"</td>
                        <td>" + item.ProductCode + @"</td>
                        <td>" + item.Price + @"</td>
                        <td>" + item.Quantity + @"</td>
                        <td>" + (item.Price * item.Quantity) + @"</td>
                    </tr>
                ")) + @"
            </tbody>
        </table>

        <div class='order-summary'>
            <p><strong>Shuma Totale me transport: </strong> " + (order.TotalPrice + order.TransportFee) + @"</p>
        </div>
    </div>
</body>
</html>";
                    bool emailToNallan = _emailService.SentEmail(confirmOrder);
                    CheckEmail(emailToNallan, confirmOrder);
                    // Commit transaction
                    scope.Complete();

                    // Clear the cart from session after order is placed
                    HttpContext.Session.Remove("Cart");

                    return Json(new { success = true, orderId = order.OrderId });
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return Json(new { success = false, msg = "blerja  deshtoi" });

                }
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult CreateBankOrder(CheckoutViewModel model)
        {
            // Get the cart items from the session
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            if (!cart.Any())
            {
                return Json(new { success = false, message = "Cart is empty!" });
            }

            // Set the transport fee based on the shipping country
            switch (model.ShipingCountry)
            {
                case "Kosovë":
                    model.TransportFee = 2;
                    break;
                case "Shqipëri":
                    model.TransportFee = 5;
                    break;
                case "Maqedoni":
                    model.TransportFee = 5;
                    break;
                default:
                    model.TransportFee = 0;
                    break;
            }

            // Create a new order
            var order = new Order
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                ShippingCity = model.ShippingCity,
                ShippingAddress = model.ShippingAddress,
                ShippingPostalCode = model.ShippingPostalCode,
                PhoneNumber = model.PhoneNumber,
                TransportFee = model.TransportFee,
                OrderDate = DateTime.Now,
                ShipingCountry = model.ShipingCountry,
                PaymentType = "BANK",
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

            _orderService.Insert(order);

            // Commit transaction

            // Clear the cart from session after order is placed
            HttpContext.Session.Remove("Cart");
            return Json(new { success = true, orderId = order.OrderId });

        }

        [AllowAnonymous]
        public IActionResult BankPayment(int OrderId)
        {
            var db = _orderService.GetById(OrderId);
            var stroeK = _configuration["TebConfiguration:StoreKey"];
            var clientK = _configuration["TebConfiguration:ClientId"];
            string storeKey = stroeK;

            Random rand = new Random();
            string randomNumber = string.Empty;

            // Generate a random number of length 20
            for (int i = 0; i < 20; i++)
            {
                randomNumber += rand.Next(0, 10); // Appends a digit (0-9)
            }
            var model = new BankRequestVM
            {
                ClientId = clientK,
                StoreType = "3d_pay_hosting",
                TranType = "Auth",
                Amount = (db.TotalPrice + db.TransportFee),
                Currency = "978",
                OkUrl = "https://nallan.eu/sq/Order/BankResponse",
                FailUrl = "https://nallan.eu/sq/Order/BankResponse",
                CallBack = "https://www.nallan.eu/sq",
                Language = "sq",
                RandomValue = randomNumber.ToString(),
                hashAlgorithm = "ver3",
                refreshtime = "5",
                installmentonHPP = "Yes",
                billToName = db.CustomerName,
                billToCompany = "NALLAN",
                OrderId = db.OrderId.ToString()
            };

            // Build parameters dictionary
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
            var hash = _hashService.GenerateHashV3(storeKey, parameters);
            model.Hash = hash;
            return View(model);

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
                    model.Response = "Pagesa u krye me sukses";

                    using (var scope = new TransactionScope())
                    {
                        try
                        {
                            var db = _orderService.GetById(orderIdd);
                            var mappedDB = _mapper.Map<OrdersViewModel>(db);
                            foreach (var item in mappedDB.OrderItems)
                            {
                                var ERP = new ErpTemp
                                {
                                    ErpStatus = 0,
                                    ArtikullEmri = item.ProductName,
                                    PaymentMethod = "BANK",
                                    SasiaPaketim = item.Quantity,
                                    DokumentID = mappedDB.OrderId,
                                    KohaRegjistrimit = DateTime.Now,
                                    CountryCode = "0",
                                    Cmimi_me_TVSH = (double)item.Price,
                                    ClientPhoneNr = mappedDB.PhoneNumber,
                                    ClientAddress = $"{mappedDB.ShippingAddress} {mappedDB.ShippingCity} {mappedDB.ShipingCountry} {mappedDB.ShippingPostalCode}",
                                    ClientName = mappedDB.CustomerName,
                                    Kodi_Shitjes = "2-1A1",
                                    ArtikullNjesia = "PALË",
                                    DataModifikim = DateTime.Now,
                                    ProductCode = item.ProductCode,
                                    ArtikullBarcode = item.GTN
                                };
                                _erpTempService.Insert(ERP);

                            }

                            if (!string.IsNullOrEmpty(mappedDB.CustomerEmail))
                            {
                                var msgReq = new EmailViewModel();
                                msgReq.EmailTo = mappedDB.CustomerEmail;
                                msgReq.Subject = "Konfirmim i porosis suaj në NALLAN.EU";
                            msgReq.Body = @"
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f8f8f8;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }
        .order-details {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }
        .order-details h2 {
            color: #4CAF50;
            font-size: 24px;
        }
        .order-details p {
            font-size: 16px;
            line-height: 1.6;
            margin: 8px 0;
        }
        .order-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .order-table th, .order-table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }
        .order-table th {
            background-color: #f4f4f4;
            color: #333;
        }
        .order-summary {
            margin-top: 20px;
            font-size: 16px;
        }
        .order-summary strong {
            color: #333;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='order-details'>
            <h2>"+mappedDB.CustomerName + @"</h2>
            <h2>Falemnderit që zgjodhet NALLAN për blerjen tuaj, porosia juaj së shpejti do të dërgohet tek ju.</h2>
        </div>

        <h3>Detajet e Porosisë:</h3>
        <table class='order-table'>
            <thead>
                <tr>
                    <th>Produkti</th>
                    <th>Kodi</th>
                    <th>Çmimi</th>
                    <th>Sasia</th>
                    <th>Gjithsej</th>
                </tr>
            </thead>
            <tbody>
                " + string.Join("", mappedDB.OrderItems.Select(item => @"
                    <tr>
                        <td>" + item.ProductName + @"</td>
                        <td>" + item.ProductCode + @"</td>
                        <td>" + item.Price + @"</td>
                        <td>" + item.Quantity + @"</td>
                        <td>" + (item.Price * item.Quantity) + @"</td>
                    </tr>
                ")) + @"
            </tbody>
        </table>

        <div class='order-summary'>
            <p><strong>Shuma Totale me transport: </strong> " + (mappedDB.TotalPrice + mappedDB.TransportFee) + @"</p>
        </div>
    </div>
</body>
</html>";
                                bool emailToClient = _emailService.SentEmail(msgReq);
                                CheckEmail(emailToClient, msgReq);
                            }
                            var confirmOrder = new EmailViewModel();
                            confirmOrder.EmailTo = "info@nallan.eu";
                            confirmOrder.Subject = "Porosi e re ne Nallan";
                            confirmOrder.Body = @"
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f8f8f8;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }
        .order-details {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }
        .order-details h2 {
            color: #4CAF50;
            font-size: 24px;
        }
        .order-details p {
            font-size: 16px;
            line-height: 1.6;
            margin: 8px 0;
        }
        .order-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .order-table th, .order-table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }
        .order-table th {
            background-color: #f4f4f4;
            color: #333;
        }
        .order-summary {
            margin-top: 20px;
            font-size: 16px;
        }
        .order-summary strong {
            color: #333;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='order-details'>
            <h2>Porosi e Re</h2>
            <p><strong>Emri i Klientit:</strong> " + mappedDB.CustomerName + @"</p>
            <p><strong>Numri i Telefonit:</strong> " + mappedDB.PhoneNumber + @"</p>
            <p><strong>Email:</strong> " + mappedDB.CustomerEmail + @"</p>
            <p><strong>Adresa:</strong> " + mappedDB.ShippingAddress + @"</p>
            <p><strong>Qyteti:</strong> " + mappedDB.ShippingCity + @"</p>
            <p><strong>Shteti:</strong> " + mappedDB.ShipingCountry + @"</p>
            <p><strong>Kodi Postal:</strong> " + mappedDB.ShippingPostalCode + @"</p>
            <p><strong>Lloji i Pageses:</strong> " + mappedDB.PaymentType + @"</p>
            <p><strong>Tarifa e Transportit:</strong> "
                            + mappedDB.TransportFee + @"</p>
            <p><strong>Data e Porosisë:</strong> " + mappedDB.OrderDate.ToString("dd/MM/yyyy HH:mm") + @"</p>
        </div>

        <h3>Detajet e Porosisë:</h3>
        <table class='order-table'>
            <thead>
                <tr>
                    <th>Produkti</th>
                    <th>Kodi/th>
                    <th>Çmimi</th>
                    <th>Sasia</th>
                    <th>Gjithsej</th>
                </tr>
            </thead>
            <tbody>
                " + string.Join("", mappedDB.OrderItems.Select(item => @"
                    <tr>
                        <td>" + item.ProductName + @"</td>
                        <td>" + item.ProductCode + @"</td>
                        <td>" + item.Price + @"</td>
                        <td>" + item.Quantity + @"</td>
                        <td>" + (item.Price * item.Quantity) + @"</td>
                    </tr>
                ")) + @"
            </tbody>
        </table>

        <div class='order-summary'>
            <p><strong>Shuma Totale me transport: </strong> " + (mappedDB.TotalPrice + mappedDB.TransportFee) + @"</p>
        </div>
    </div>
</body>
</html>";
                            bool emailToNallan = _emailService.SentEmail(confirmOrder);
                            CheckEmail(emailToNallan, confirmOrder);
                            // Commit transaction
                            scope.Complete();
                            return RedirectToAction("OrderConfirmation", new { OrderId = mappedDB.OrderId });
                        }
                        catch (Exception ex)
                        {
                            scope.Dispose();
                            return Json(new { success = false, msg = "blerja  deshtoi" });

                        }
                    }
                }
                else if (prc == "99" || res == "Error”")
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
            // Depending on the response format from the payment gateway, you need to extract the URL
            // For example, it could be a JSON response like:
            // { "redirectUrl": "https://payment-gateway-url.com" }

            // Placeholder extraction logic
            // You may need to parse the response as JSON or HTML, depending on how it's formatted

            // If the response contains the URL directly, extract it here:
            if (content.Contains("redirectUrl"))
            {
                // Example extraction (this will vary based on the response structure)
                var start = content.IndexOf("redirectUrl") + 13; // Assuming the URL is after the key
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


    }
}