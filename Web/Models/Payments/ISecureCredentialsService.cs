using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Models.Payments
{
    public interface ISecureCredentialsService
    {
        /// <summary>
        /// Get secure credentials container
        /// </summary>
        Task<SecureCredentialsContainer> GetCredentialsAsync();

        /// <summary>
        /// Generate secure hash for payment parameters
        /// </summary>
        Task<string> GenerateSecureHashAsync(Dictionary<string, string> parameters);

        /// <summary>
        /// Validate hash from bank response
        /// </summary>
        Task<bool> ValidateHashAsync(Dictionary<string, string> formData, string receivedHash);

        /// <summary>
        /// Generate secure token for payment sessions
        /// </summary>
        Task<string> GenerateSecureTokenAsync(string data);
    }
}