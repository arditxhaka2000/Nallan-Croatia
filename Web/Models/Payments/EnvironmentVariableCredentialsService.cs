using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.InteropServices;
using Web.Models.TebBank;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Services.TEBPayments;

namespace Web.Models.Payments
{
    public class EnvironmentVariableCredentialsService : ISecureCredentialsService
    {
        private readonly IDataProtector _protector;
        private readonly IHashService _hashService;
        private readonly ILogger<EnvironmentVariableCredentialsService> _logger;
        private readonly EncryptedCredentials _encryptedCredentials;

        public EnvironmentVariableCredentialsService(
            IDataProtectionProvider dataProtectionProvider,
            IHashService hashService,
            ILogger<EnvironmentVariableCredentialsService> logger)
        {
            _protector = dataProtectionProvider.CreateProtector("EnvironmentVariableCredentialsService.Credentials");
            _hashService = hashService;
            _logger = logger;

            // Load and encrypt credentials from environment variables immediately
            _encryptedCredentials = LoadAndEncryptCredentials();
        }

        public async Task<SecureCredentialsContainer> GetCredentialsAsync()
        {
            await Task.CompletedTask;
            return DecryptCredentials(_encryptedCredentials);
        }

        public async Task<string> GenerateSecureHashAsync(Dictionary<string, string> parameters)
        {
            using var credentials = await GetCredentialsAsync();

            // Add client ID to parameters securely
            var parametersWithClientId = new Dictionary<string, string>(parameters)
            {
                ["clientid"] = SecureStringToString(credentials.ClientId)
            };

            var hash = _hashService.GenerateHashV3(SecureStringToString(credentials.StoreKey), parametersWithClientId);

            // Clear sensitive parameters
            ClearSensitiveData(parametersWithClientId);

            return hash;
        }

        public async Task<bool> ValidateHashAsync(Dictionary<string, string> formData, string receivedHash)
        {
            using var credentials = await GetCredentialsAsync();

            var calculatedHash = _hashService.GenerateHashV3(SecureStringToString(credentials.StoreKey), formData);

            // Timing-safe comparison
            return SecureStringCompare(receivedHash, calculatedHash);
        }

        public async Task<string> GenerateSecureTokenAsync(string data)
        {
            using var credentials = await GetCredentialsAsync();

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(SecureStringToString(credentials.StoreKey)));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hash);
        }

        // Private helper methods
        private EncryptedCredentials LoadAndEncryptCredentials()
        {
            try
            {
                // Load credentials from environment variables
                var clientId = Environment.GetEnvironmentVariable("TEBBANK_CLIENT_ID");
                var userName = Environment.GetEnvironmentVariable("TEBBANK_USERNAME");
                var password = Environment.GetEnvironmentVariable("TEBBANK_PASSWORD");
                var storeKey = Environment.GetEnvironmentVariable("TEBBANK_STORE_KEY");
                var apiUserName = Environment.GetEnvironmentVariable("TEBBANK_API_USERNAME");
                var apiPassword = Environment.GetEnvironmentVariable("TEBBANK_API_PASSWORD");

                // Validate all required variables are present
                if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storeKey) ||
                    string.IsNullOrEmpty(apiUserName) || string.IsNullOrEmpty(apiPassword))
                {
                    throw new InvalidOperationException("One or more required TEB Bank environment variables are missing");
                }

                // Encrypt credentials immediately
                var encrypted = new EncryptedCredentials
                {
                    ClientId = _protector.Protect(clientId),
                    UserName = _protector.Protect(userName),
                    Password = _protector.Protect(password),
                    StoreKey = _protector.Protect(storeKey),
                    ApiUserName = _protector.Protect(apiUserName),
                    ApiPassword = _protector.Protect(apiPassword)
                };

                _logger.LogInformation("TEB Bank credentials loaded and encrypted successfully");
                return encrypted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load TEB Bank credentials from environment variables");
                throw new InvalidOperationException("Unable to load TEB Bank credentials", ex);
            }
        }

        private SecureCredentialsContainer DecryptCredentials(EncryptedCredentials encrypted)
        {
            try
            {
                return new SecureCredentialsContainer
                {
                    ClientId = StringToSecureString(_protector.Unprotect(encrypted.ClientId)),
                    UserName = StringToSecureString(_protector.Unprotect(encrypted.UserName)),
                    Password = StringToSecureString(_protector.Unprotect(encrypted.Password)),
                    StoreKey = StringToSecureString(_protector.Unprotect(encrypted.StoreKey)),
                    ApiUserName = StringToSecureString(_protector.Unprotect(encrypted.ApiUserName)),
                    ApiPassword = StringToSecureString(_protector.Unprotect(encrypted.ApiPassword))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to decrypt TEB Bank credentials");
                throw new InvalidOperationException("Unable to decrypt credentials", ex);
            }
        }

        private void ClearSensitiveData(Dictionary<string, string> data)
        {
            var sensitiveKeys = new[] { "clientid", "storekey", "password", "apipassword" };

            foreach (var key in data.Keys.Where(k => sensitiveKeys.Contains(k.ToLowerInvariant())).ToList())
            {
                data[key] = GenerateRandomString(data[key].Length);
                data[key] = "";
            }
        }

        private SecureString StringToSecureString(string input)
        {
            if (string.IsNullOrEmpty(input)) return new SecureString();

            var secureString = new SecureString();
            foreach (char c in input)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
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

        private bool SecureStringCompare(string a, string b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            var result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }
            return result == 0;
        }

        private string GenerateRandomString(int length)
        {
            if (length <= 0) return "";

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[length];
            rng.GetBytes(bytes);

            return new string(bytes.Select(b => chars[b % chars.Length]).ToArray());
        }
    }

    // Supporting classes
    public class EncryptedCredentials
    {
        public string ClientId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string StoreKey { get; set; } = "";
        public string ApiUserName { get; set; } = "";
        public string ApiPassword { get; set; } = "";
    }

    public class SecureCredentialsContainer : IDisposable
    {
        public SecureString ClientId { get; set; } = new();
        public SecureString UserName { get; set; } = new();
        public SecureString Password { get; set; } = new();
        public SecureString StoreKey { get; set; } = new();
        public SecureString ApiUserName { get; set; } = new();
        public SecureString ApiPassword { get; set; } = new();

        public void Dispose()
        {
            ClientId?.Dispose();
            UserName?.Dispose();
            Password?.Dispose();
            StoreKey?.Dispose();
            ApiUserName?.Dispose();
            ApiPassword?.Dispose();
        }
    }
}