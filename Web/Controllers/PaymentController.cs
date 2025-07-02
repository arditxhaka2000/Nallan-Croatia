using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection;
using Services.TEBPayments;
using Web.Models;
using Web.Models.TebBank;
using System.Security;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Web.Models.Payment;
using Web.Models.Payments;

namespace Web.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IHashService _hashService;
        private readonly ILogger<PaymentController> _logger;
        private readonly TebBankSettings _tebBankSettings;
        private readonly ISecureCredentialsService _credentialsService;
        private readonly IDataProtector _dataProtector;
        private readonly IPaymentSessionService _sessionService;
        public PaymentController(
            IHashService hashService,
            ILogger<PaymentController> logger,
            IOptions<TebBankSettings> tebBankSettings,
            ISecureCredentialsService credentialsService,
            IPaymentSessionService sessionService,
            IDataProtectionProvider dataProtectionProvider)
        {
            _hashService = hashService;
            _logger = logger;
            _tebBankSettings = tebBankSettings.Value;
            _credentialsService = credentialsService;
            _sessionService = sessionService;
            _dataProtector = dataProtectionProvider.CreateProtector("PaymentController.Credentials");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiatePayment(PaymentInitiationRequest request)
        {
            try
            {
                // Input validation
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid payment initiation request for order {OrderId}",
                        SanitizeForLogging(request.OrderId));
                    return BadRequest(ModelState);
                }

                if (!IsValidAmount(request.Amount))
                {
                    _logger.LogWarning("Invalid amount for order {OrderId}",
                        SanitizeForLogging(request.OrderId));
                    return BadRequest("Invalid payment amount");
                }

                // Verify order ownership and status
                var order = await GetAndValidateOrderAsync(request.OrderId, User.Identity.Name ?? "anonymous");
                if (order == null)
                {
                    _logger.LogWarning("Order not found or unauthorized access by user {UserId}",
                        GetHashedUserId(User.Identity.Name ?? "anonymous"));
                    return NotFound("Order not found");
                }

                if (!order.CanBePaid)
                {
                    _logger.LogWarning("Attempt to pay for non-payable order {OrderId} with status {Status}",
                        SanitizeForLogging(request.OrderId), order.Status);
                    return BadRequest("Order is not available for payment");
                }

                // Verify amounts match
                if (Math.Abs(order.Amount - request.Amount) > 0.01m)
                {
                    _logger.LogWarning("Amount mismatch for order {OrderId}. Order: {OrderAmount}, Request: {RequestAmount}",
                        SanitizeForLogging(request.OrderId), order.Amount, request.Amount);
                    return BadRequest("Payment amount does not match order amount");
                }

                // Create payment session
                var session = await _sessionService.CreateSessionAsync(
                    request.OrderId,
                    request.Amount,
                    User.Identity.Name ?? "anonymous",
                    _tebBankSettings.SessionTimeoutMinutes);

                // Generate secure nonce
                var nonce = GenerateSecureNonce();

                // Create payment parameters
                var parameters = await CreatePaymentParametersAsync(request, order, nonce, session.Token);

                // Generate hash using secure service
                var hash = await _credentialsService.GenerateSecureHashAsync(parameters);

                _logger.LogInformation("Payment initiated for order {OrderId}, session {SessionToken}, user {UserId}",
                    SanitizeForLogging(request.OrderId), SanitizeForLogging(session.Token), GetHashedUserId(User.Identity.Name ?? "anonymous"));

                // Create view model (ClientId will be retrieved securely)
                var model = await CreateBankRequestModelAsync(request, parameters, hash, session.Token);

                return View("BankPayment", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initiating payment for order {OrderId}",
                    SanitizeForLogging(request.OrderId));
                return View("PaymentError", new { Error = "Payment initiation failed. Please try again." });
            }
        }
        private async Task<Dictionary<string, string>> CreatePaymentParametersAsync(
    PaymentInitiationRequest request,
    OrderModel order,
    string nonce,
    string sessionToken)
        {
            await Task.CompletedTask;

            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            return new Dictionary<string, string>
            {
                ["amount"] = request.Amount.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                ["oid"] = request.OrderId,
                ["okurl"] = request.ReturnUrl ?? $"{baseUrl}/payment/paymentsuccess?token={sessionToken}",
                ["failurl"] = request.CancelUrl ?? $"{baseUrl}/payment/paymentfailed?token={sessionToken}",
                ["callbackurl"] = $"{baseUrl}/payment/paymentcallback?token={sessionToken}",
                ["trantype"] = _tebBankSettings.TransactionType,
                ["installment"] = _tebBankSettings.InstallmentOptions,
                ["rnd"] = nonce,
                ["currency"] = _tebBankSettings.Currency,
                ["storetype"] = _tebBankSettings.StoreType,
                ["hashAlgorithm"] = _tebBankSettings.HashAlgorithm,
                ["lang"] = _tebBankSettings.Language,
                ["refreshtime"] = _tebBankSettings.RefreshTime,
                ["BillToName"] = SanitizeInput(order.CustomerName ?? ""),
                ["BillToCompany"] = SanitizeInput(order.CustomerCompany ?? "")
            };
        }

        private async Task<BankRequestVM> CreateBankRequestModelAsync(
            PaymentInitiationRequest request,
            Dictionary<string, string> parameters,
            string hash,
            string sessionToken)
        {
            // Get client ID securely
            using var credentials = await _credentialsService.GetCredentialsAsync();
            var clientId = SecureStringToString(credentials.ClientId);

            return new BankRequestVM
            {
                ClientId = clientId,
                Amount = request.Amount,
                OrderId = request.OrderId,
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
        }

        private bool IsValidAmount(decimal amount) =>
            amount >= _tebBankSettings.MinAmount && amount <= _tebBankSettings.MaxAmount && amount > 0;

        private string GenerateSecureNonce()
        {
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            var bytes = new byte[16];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes).Replace("+", "").Replace("/", "").Replace("=", "");
        }

        private string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            return input.Replace("<", "").Replace(">", "").Replace("\"", "").Replace("'", "")
                       .Replace("javascript:", "").Replace("vbscript:", "")
                       .Replace("data:", "").Replace("blob:", "").Trim();
        }

        private string SanitizeForLogging(string input)
        {
            if (string.IsNullOrEmpty(input)) return "empty";

            if (input.Length > 8)
                return $"{input[..4]}****{input[^4..]}";

            return "****";
        }

        private string GetHashedUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return "anonymous";

            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userId));
            return Convert.ToHexString(hash)[..8];
        }

        private string SecureStringToString(System.Security.SecureString secureString)
        {
            if (secureString == null) return "";

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ptr) ?? "";
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> PaymentCallback(string token)
        {
            try
            {
                // Validate token first
                var session = await GetPaymentSessionAsync(token);
                if (session == null || session.IsExpired)
                {
                    _logger.LogWarning("Invalid or expired payment session");
                    return BadRequest("Invalid payment session");
                }

                var formData = new Dictionary<string, string>();
                foreach (var key in Request.Form.Keys)
                {
                    // Sanitize all form data
                    formData[key] = SanitizeInput(Request.Form[key].ToString());
                }

                var receivedOrderId = formData.ContainsKey("oid") ? formData["oid"] : "";
                if (receivedOrderId != session.OrderId)
                {
                    _logger.LogWarning("Order ID mismatch in payment callback");
                    return BadRequest("Order validation failed");
                }

                // Validate hash using secure service
                var receivedHash = formData.ContainsKey("HASH") ? formData["HASH"] : "";
                var isHashValid = await _credentialsService.ValidateHashAsync(formData, receivedHash);

                var isSuccess = isHashValid && ValidatePaymentResponse(formData);

                // Validate amount without logging actual values
                if (formData.ContainsKey("amount") && decimal.TryParse(formData["amount"], out var receivedAmount))
                {
                    if (Math.Abs(receivedAmount - session.Amount) > 0.01m)
                    {
                        _logger.LogWarning("Amount mismatch in payment callback for order {OrderId}",
                            SanitizeForLogging(session.OrderId));
                        isSuccess = false;
                    }
                }

                var responseModel = new PaymentResponseViewModel
                {
                    Response = formData.ContainsKey("Response") ? SanitizeInput(formData["Response"]) : "",
                    AuthCode = formData.ContainsKey("AuthCode") ? SanitizeInput(formData["AuthCode"]) : "",
                    HostRefNum = formData.ContainsKey("HostRefNum") ? SanitizeInput(formData["HostRefNum"]) : "",
                    ProcReturnCode = formData.ContainsKey("ProcReturnCode") ? SanitizeInput(formData["ProcReturnCode"]) : "",
                    TransId = formData.ContainsKey("TransId") ? SanitizeInput(formData["TransId"]) : "",
                    MdStatus = formData.ContainsKey("mdStatus") ? SanitizeInput(formData["mdStatus"]) : "",
                    IsSuccess = isSuccess
                };

                if (isSuccess)
                {
                    await ProcessSuccessfulPaymentAsync(session.OrderId, responseModel);
                    _logger.LogInformation("Payment successful for order {OrderId}",
                        SanitizeForLogging(session.OrderId));
                }
                else
                {
                    await ProcessFailedPaymentAsync(session.OrderId, responseModel);
                    _logger.LogWarning("Payment failed for order {OrderId}",
                        SanitizeForLogging(session.OrderId));
                }

                await InvalidatePaymentSessionAsync(token);

                // Clear form data from memory
                ClearSensitiveData(formData);

                return View("BankResponse", responseModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment callback");
                return View("PaymentError", new { Error = "Payment processing failed" });
            }
        }

        // Security helper methods
        private Dictionary<string, string> CreatePaymentParameters(PaymentInitiationRequest request, OrderModel order, string nonce, string sessionToken)
        {
            return new Dictionary<string, string>
            {
                ["amount"] = request.Amount.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                ["oid"] = request.OrderId,
                ["okurl"] = Url.Action("PaymentSuccess", "Payment", new { token = sessionToken }, Request.Scheme),
                ["failurl"] = Url.Action("PaymentFailed", "Payment", new { token = sessionToken }, Request.Scheme),
                ["callbackurl"] = Url.Action("PaymentCallback", "Payment", new { token = sessionToken }, Request.Scheme),
                ["trantype"] = _tebBankSettings.TransactionType,
                ["installment"] = "",
                ["rnd"] = nonce,
                ["currency"] = _tebBankSettings.Currency,
                ["storetype"] = _tebBankSettings.StoreType,
                ["hashAlgorithm"] = _tebBankSettings.HashAlgorithm,
                ["lang"] = _tebBankSettings.Language,
                ["refreshtime"] = _tebBankSettings.RefreshTime,
                ["BillToName"] = SanitizeInput(order.CustomerName ?? ""),
                ["BillToCompany"] = SanitizeInput(order.CustomerCompany ?? "")
            };
        }

        private BankRequestVM CreateBankRequestModel(PaymentInitiationRequest request, Dictionary<string, string> parameters, string hash, string sessionToken)
        {
            return new BankRequestVM
            {
                // Note: ClientId will be retrieved securely when needed
                Amount = request.Amount,
                OrderId = request.OrderId,
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
        }

        private void ClearSensitiveData(Dictionary<string, string> data)
        {
            if (data == null) return;

            foreach (var key in data.Keys.ToList())
            {
                if (IsSensitiveField(key))
                {
                    // Overwrite with random data before clearing
                    data[key] = GenerateRandomString(data[key].Length);
                    data[key] = "";
                }
            }
            data.Clear();
        }

        private bool IsSensitiveField(string fieldName)
        {
            var sensitiveFields = new[] { "clientid", "hash", "storekey", "password", "apipassword" };
            return sensitiveFields.Contains(fieldName.ToLowerInvariant());
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private async Task<string> GeneratePaymentTokenAsync(string orderId, decimal amount, string nonce, long timestamp)
        {
            var data = $"{orderId}|{amount}|{nonce}|{timestamp}";
            return await _credentialsService.GenerateSecureTokenAsync(data);
        }

        private bool ValidatePaymentResponse(Dictionary<string, string> formData)
        {
            var response = formData.ContainsKey("Response") ? formData["Response"] : "";
            var procReturnCode = formData.ContainsKey("ProcReturnCode") ? formData["ProcReturnCode"] : "";
            var mdStatus = formData.ContainsKey("mdStatus") ? formData["mdStatus"] : "";

            var successfulMdStatuses = new[] { "1", "2", "3", "4" };

            return response.Equals("Approved", StringComparison.OrdinalIgnoreCase) &&
                   procReturnCode == "00" &&
                   successfulMdStatuses.Contains(mdStatus);
        }

        // Placeholder async methods - implement based on your needs
        private async Task<OrderModel> GetAndValidateOrderAsync(string orderId, string userId)
        {
            await Task.CompletedTask;
            return new OrderModel { OrderId = orderId, Status = OrderStatus.Pending, Amount = 100m };
        }

        private async Task StorePaymentSessionAsync(string token, string orderId, decimal amount, int expiryMinutes)
        {
            await Task.CompletedTask;
        }

        private async Task<PaymentSession> GetPaymentSessionAsync(string token)
        {
            await Task.CompletedTask;
            return new PaymentSession { Token = token, OrderId = "123", Amount = 100m };
        }

        private async Task InvalidatePaymentSessionAsync(string token)
        {
            await Task.CompletedTask;
        }

        private async Task ProcessSuccessfulPaymentAsync(string orderId, PaymentResponseViewModel response)
        {
            await Task.CompletedTask;
        }

        private async Task ProcessFailedPaymentAsync(string orderId, PaymentResponseViewModel response)
        {
            await Task.CompletedTask;
        }
    }
}