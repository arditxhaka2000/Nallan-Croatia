using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using Web.Services.CorvusPayments;

namespace Services.CorvusPayments
{
    public class SecureCredentialsService : ISecureCredentialsService
    {
        private readonly IConfiguration _configuration;

        public SecureCredentialsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<SecureCredentials> GetCredentialsAsync()
        {
            var credentials = new SecureCredentials
            {
                StoreId = CreateSecureString(_configuration["CorvusPaySettings:StoreId"]),
                SecretKey = CreateSecureString(_configuration["CorvusPaySettings:SecretKey"])
            };
            return Task.FromResult(credentials);
        }

        public Task<string> GenerateSecureHashAsync(Dictionary<string, string> parameters)
        {
            var secretKey = _configuration["CorvusPaySettings:SecretKey"];
            var dataToSign = string.Join("", new[]
            {
                parameters.GetValueOrDefault("version", ""),
                parameters.GetValueOrDefault("store_id", ""),
                parameters.GetValueOrDefault("order_number", ""),
                parameters.GetValueOrDefault("amount", ""),
                parameters.GetValueOrDefault("currency", ""),
                secretKey
            });

            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                var hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dataToSign));
                return Task.FromResult(Convert.ToHexString(hash).ToLower());
            }
        }

        private SecureString CreateSecureString(string input)
        {
            var secureString = new SecureString();
            if (!string.IsNullOrEmpty(input))
            {
                foreach (char c in input)
                {
                    secureString.AppendChar(c);
                }
            }
            secureString.MakeReadOnly();
            return secureString;
        }
    }
}