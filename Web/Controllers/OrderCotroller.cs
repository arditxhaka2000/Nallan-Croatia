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
using Web.Models.EmailTemplates;

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
    }
}