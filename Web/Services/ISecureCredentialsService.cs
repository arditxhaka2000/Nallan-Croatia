using System.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CorvusPayments
{
    public interface ISecureCredentialsService
    {
        Task<SecureCredentials> GetCredentialsAsync();
        Task<string> GenerateSecureHashAsync(Dictionary<string, string> parameters);
    }

    public class SecureCredentials
    {
        public SecureString StoreId { get; set; }
        public SecureString SecretKey { get; set; }
    }
}