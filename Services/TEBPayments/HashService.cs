using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Services.TEBPayments
{
    public class HashService : IHashService
    {
        public string GenerateHashV3(string storeKey, Dictionary<string, string> parameters)
        {
                // Step 1: Sort the parameters alphabetically by key (case-insensitive)
                var orderedParameters = parameters
                    .Where(p => p.Key.ToLowerInvariant() != "encoding" &&
                                p.Key.ToLowerInvariant() != "hash" &&
                                p.Key.ToLowerInvariant() != "reservedReturnMerchant")
                    .OrderBy(p => p.Key, StringComparer.OrdinalIgnoreCase); // Case-insensitive sorting

                // Step 2: Build the plaintext string by concatenating parameter values in the correct order
                var hashInput = new StringBuilder();
                foreach (var param in orderedParameters)
                {
                    string value = param.Value ?? ""; // Use empty string if value is null
                    var escapedValue = value
                        .Replace("\\", "\\\\") // Escape backslashes
                        .Replace("|", "\\|");  // Escape pipe characters

                    hashInput.Append(escapedValue).Append("|");
                }

                // Step 3: Append the escaped storeKey to the hash input
                var escapedStoreKey = storeKey
                    .Replace("\\", "\\\\") // Escape backslashes
                    .Replace("|", "\\|");  // Escape pipe characters
                hashInput.Append(escapedStoreKey);

                // Step 4: Generate the SHA-512 hash of the input string
                string sha512HashHex = ComputeSha512Hex(hashInput.ToString());

                // Step 5: Convert the hexadecimal hash to Base64 (equivalent to PHP's pack('H*') + base64_encode)
                string base64Hash = ConvertHexToBase64(sha512HashHex);

                return base64Hash;
            }

            private string ComputeSha512Hex(string input)
            {
            using (var sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(Encoding.GetEncoding("ISO-8859-9").GetBytes(input)); // Use ISO-8859-9 encoding
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant(); // Convert to hex
            }

        }

        private string ConvertHexToBase64(string hex)
            {
                // Convert hexadecimal string to byte array
                byte[] bytes = Enumerable.Range(0, hex.Length / 2)
                    .Select(i => Convert.ToByte(hex.Substring(i * 2, 2), 16))
                    .ToArray();

                // Convert byte array to Base64 string
                return Convert.ToBase64String(bytes);
            }
        } 
}
