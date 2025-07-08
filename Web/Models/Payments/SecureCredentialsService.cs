using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Web.Models.Payments;

namespace Web.Models.Payments
{
    public class SecureCredentialsService : ISecureCredentialsService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SecureCredentialsService> _logger;
        private readonly IDataProtector _dataProtector;

        public SecureCredentialsService(
            IConfiguration configuration,
            ILogger<SecureCredentialsService> logger,
            IDataProtectionProvider dataProtectionProvider)
        {
            _configuration = configuration;
            _logger = logger;
            _dataProtector = dataProtectionProvider.CreateProtector("TebBank.Credentials");
        }

        public async Task<SecureCredentialsContainer> GetCredentialsAsync()
        {
            await Task.CompletedTask;

            try
            {
                _logger.LogDebug("Retrieving TEB Bank credentials");

                var container = new SecureCredentialsContainer();

                // Get credentials from environment variables or configuration
                var clientId = GetCredentialValue("TEB_CLIENT_ID", "TebBank:ClientId");
                var storeKey = GetCredentialValue("TEB_STORE_KEY", "TebBank:StoreKey");
                var username = GetCredentialValue("TEB_USERNAME", "TebBank:Username");
                var password = GetCredentialValue("TEB_PASSWORD", "TebBank:Password");

                // Validate that all required credentials are present
                if (string.IsNullOrEmpty(clientId))
                    throw new InvalidOperationException("TEB_CLIENT_ID is missing");
                if (string.IsNullOrEmpty(storeKey))
                    throw new InvalidOperationException("TEB_STORE_KEY is missing");
                if (string.IsNullOrEmpty(username))
                    throw new InvalidOperationException("TEB_USERNAME is missing");
                if (string.IsNullOrEmpty(password))
                    throw new InvalidOperationException("TEB_PASSWORD is missing");

                // Convert to SecureString
                container.ClientId = CreateSecureString(clientId);
                container.StoreKey = CreateSecureString(storeKey);

                _logger.LogInformation("TEB Bank credentials loaded successfully");
                return container;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load TEB Bank credentials");
                throw new InvalidOperationException("Unable to load TEB Bank credentials", ex);
            }
        }

        public async Task<string> GenerateSecureHashAsync(Dictionary<string, string> parameters)
        {
            try
            {
                _logger.LogDebug("Generating secure hash for payment parameters");

                // Get credentials
                using var credentials = await GetCredentialsAsync();
                var storeKey = SecureStringToString(credentials.StoreKey);
                var clientId = SecureStringToString(credentials.ClientId);

                // Add client ID to parameters if not present
                if (!parameters.ContainsKey("clientid"))
                {
                    parameters["clientid"] = clientId;
                }

                // Build hash string according to TEB Bank specification
                var hashString = BuildTebBankHashString(parameters, storeKey);

                _logger.LogDebug("Hash string built, generating SHA-512 hash");

                // Generate SHA-512 hash
                using var sha512 = SHA512.Create();
                var hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(hashString));
                var hash = Convert.ToBase64String(hashBytes);

                _logger.LogDebug("Secure hash generated successfully");
                return hash;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating secure hash");
                throw;
            }
        }

        public async Task<bool> ValidateHashAsync(Dictionary<string, string> formData, string receivedHash)
        {
            try
            {
                _logger.LogDebug("Validating payment response hash");

                if (string.IsNullOrEmpty(receivedHash))
                {
                    _logger.LogWarning("Received hash is empty");
                    return false;
                }

                // Create a copy of form data without the hash fields
                var parametersForValidation = new Dictionary<string, string>(formData);
                parametersForValidation.Remove("HASH");
                parametersForValidation.Remove("hash");
                parametersForValidation.Remove("Hash");

                // Generate expected hash
                var expectedHash = await GenerateSecureHashAsync(parametersForValidation);

                // Compare hashes (case-insensitive)
                var isValid = string.Equals(expectedHash, receivedHash, StringComparison.OrdinalIgnoreCase);

                _logger.LogDebug("Hash validation result: {IsValid}", isValid);

                if (!isValid)
                {
                    _logger.LogWarning("Hash validation failed - received hash does not match expected hash");
                }

                return isValid;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating hash");
                return false;
            }
        }

        public async Task<string> GenerateSecureTokenAsync(string data)
        {
            await Task.CompletedTask;

            try
            {
                _logger.LogDebug("Generating secure token");

                // Generate cryptographically secure random bytes
                using var rng = RandomNumberGenerator.Create();
                var randomBytes = new byte[32];
                rng.GetBytes(randomBytes);

                // Combine input data with timestamp and random bytes
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var combinedData = $"{data}|{timestamp}|{Convert.ToBase64String(randomBytes)}";

                // Hash the combined data
                using var sha256 = SHA256.Create();
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedData));

                // Convert to URL-safe base64
                var token = Convert.ToBase64String(hashBytes)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .TrimEnd('=');

                _logger.LogDebug("Secure token generated successfully");
                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating secure token");
                throw;
            }
        }

        #region Private Helper Methods

        private string GetCredentialValue(string envVarName, string configPath)
        {
            // First try environment variable
            var value = Environment.GetEnvironmentVariable(envVarName);

            if (!string.IsNullOrEmpty(value))
            {
                _logger.LogDebug("Credential {EnvVar} loaded from environment variable", envVarName);
                return value;
            }

            // Then try configuration
            value = _configuration[configPath];

            if (!string.IsNullOrEmpty(value))
            {
                _logger.LogDebug("Credential {ConfigPath} loaded from configuration", configPath);
                return value;
            }

            _logger.LogWarning("Credential not found: {EnvVar} or {ConfigPath}", envVarName, configPath);
            return null;
        }

        private string BuildTebBankHashString(Dictionary<string, string> parameters, string storeKey)
        {
            // TEB Bank hash string order (adjust based on your bank's documentation)
            var orderedParams = new[]
            {
                "clientid", "oid", "amount", "okurl", "failurl", "trantype",
                "installment", "rnd", "currency", "storetype", "hashAlgorithm",
                "lang", "refreshtime", "BillToName", "BillToCompany"
            };

            var hashStringBuilder = new StringBuilder();

            // Add parameters in the required order
            foreach (var paramName in orderedParams)
            {
                if (parameters.ContainsKey(paramName))
                {
                    var value = parameters[paramName] ?? string.Empty;
                    hashStringBuilder.Append(value);
                    _logger.LogTrace("Added parameter {ParamName} to hash string", paramName);
                }
            }

            // Add store key at the end
            hashStringBuilder.Append(storeKey);

            var hashString = hashStringBuilder.ToString();
            _logger.LogTrace("Final hash string length: {Length}", hashString.Length);

            return hashString;
        }

        private SecureString CreateSecureString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new SecureString();
            }

            var secureString = new SecureString();
            foreach (char c in value)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
        }

        private string SecureStringToString(SecureString secureString)
        {
            if (secureString == null || secureString.Length == 0)
            {
                return string.Empty;
            }

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(ptr) ?? string.Empty;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(ptr);
                }
            }
        }

        #endregion
    }
   
}
