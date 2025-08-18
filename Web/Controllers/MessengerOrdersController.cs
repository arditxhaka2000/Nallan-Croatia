using Microsoft.AspNetCore.Mvc;
using Services.Orders;
using Services;
using Services.Emails;
using SimpleEmailApp.Services.EmailService;
using Web.Filters;
using Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Services.ProductServ;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/messenger-orders")]
    public class MessengerOrdersController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IErpTempService _erpTempService;
        private readonly IEmailService _emailService;
        private readonly IEmailsService _emailsService;
        private readonly IApiServices _apiServices;

        public MessengerOrdersController(
            IProductService productService,
            IOrderService orderService,
            IErpTempService erpTempService,
            IEmailService emailService,
            IEmailsService emailsService,
            IApiServices apiServices)
        {
            _productService = productService;
            _orderService = orderService;
            _erpTempService = erpTempService;
            _emailService = emailService;
            _emailsService = emailsService;
            _apiServices = apiServices;
        }

        [HttpPost]
        [ApiKeyAuth]
        public async Task<IActionResult> CreateOrder([FromBody] MessengerOrderRequest request)
        {
            try
            {
                // Validate required fields
                if (request == null || string.IsNullOrEmpty(request.ProductId) ||
                    string.IsNullOrEmpty(request.CustomerFirstName) ||
                    string.IsNullOrEmpty(request.CustomerPhone))
                {
                    return BadRequest(new { success = false, message = "Required fields missing" });
                }

                // Get product details
                var product = await GetProductDetailsById(request.ProductId);
                if (product == null)
                {
                    return BadRequest(new { success = false, message = "Product not found" });
                }

                // Create the order
                var order = new Order
                {
                    CustomerName = $"{request.CustomerFirstName} {request.CustomerLastName}".Trim(),
                    CustomerEmail = request.CustomerEmail ?? "",
                    ShippingCity = ExtractCityFromAddress(request.CustomerAddress),
                    ShippingAddress = request.CustomerAddress,
                    ShippingPostalCode = "",
                    PhoneNumber = request.CustomerPhone,
                    TransportFee = 4, // Default transport fee
                    OrderDate = DateTime.Now,
                    ShipingCountry = "Kosovo",
                    PaymentType = "CASH", // Messenger orders are cash on delivery
                    CreatedById = null, // No user authentication for messenger orders
                    TotalPrice = request.TotalPrice > 0 ? request.TotalPrice : product.Price,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            ProductCode = request.ProductId,
                            ProductName = product.Name,
                            Price = request.TotalPrice > 0 ? request.TotalPrice : product.Price,
                            Quantity = 1,
                            Size = ExtractSizeFromNotes(request.Notes),
                            ImagePath = product.ImageUrl ?? "",
                            GTN = product.Barcode ?? request.ProductId
                        }
                    }
                };

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
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
                            var msgReq = new Models.EmailConfig.EmailViewModel
                            {
                                EmailTo = order.CustomerEmail,
                                Subject = "Konfirmimi i porosisë - NALLAN.EU",
                                Body = CreateMessengerOrderEmailTemplate(order)
                            };

                            bool emailToClient = _emailService.SentEmail(msgReq);
                            CheckEmail(emailToClient, msgReq);
                        }

                        // Send internal notification
                        var internalNotification = new Models.EmailConfig.EmailViewModel
                        {
                            EmailTo = "info@nallan.eu",
                            Subject = $"Porosi e re nga Facebook Messenger - {order.CustomerName}",
                            Body = CreateInternalMessengerNotificationTemplate(order, request.Source, request.Notes)
                        };

                        bool emailToNallan = _emailService.SentEmail(internalNotification);
                        CheckEmail(emailToNallan, internalNotification);

                        scope.Complete();

                        return Ok(new
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
                        return BadRequest(new { success = false, message = "Order creation failed: " + ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error processing order: " + ex.Message });
            }
        }

        [HttpGet("{orderId}")]
        [ApiKeyAuth]
        public IActionResult GetOrderStatus(int orderId)
        {
            try
            {
                var order = _orderService.GetById(orderId);
                if (order == null)
                {
                    return NotFound(new { success = false, message = "Order not found" });
                }

                return Ok(new
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
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        #region Helper Methods

        private async Task<ProductDetails> GetProductDetailsById(string productId)
        {
            try
            {
                // Get product from your product service
                var productDB = await _apiServices.GetAllAsync("sq");

                if (productDB == null)
                    return null;

                var product = productDB.Find(i=>i.ProductCode == productId);
                return new ProductDetails
                {
                    Id = product.ProductCode,
                    Name = product.Title,
                    Price = product.Price,
                    ImageUrl = "",
                    Barcode =  productId
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

            // Simple city extraction - enhance as needed
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

        private void CheckEmail(bool emailIsSent, Models.EmailConfig.EmailViewModel model)
        {
            var sendEmail = new SendEmail
            {
                Body = model.Body,
                Subject = model.Subject,
                Date = DateTime.Now,
                EmailTo = model.EmailTo,
                IsSended = emailIsSent,
                Queue = !emailIsSent,
                SendedFromSystem = true
            };
            _emailsService.Insert(sendEmail);
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

        #region Data Models

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

        public class ProductDetails
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public string Barcode { get; set; }
        }

        

        #endregion
    }
}