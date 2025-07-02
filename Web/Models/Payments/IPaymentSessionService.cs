using System.Threading.Tasks;
using Web.Models.Payment;

namespace Web.Models.Payments
{
    public interface IPaymentSessionService
    {
        Task<PaymentSession> CreateSessionAsync(string orderId, decimal amount, string userId, int? timeoutMinutes = null);
        Task<PaymentSession> GetSessionAsync(string token);
        Task<bool> ValidateSessionAsync(string token, string orderId, decimal amount);
        Task InvalidateSessionAsync(string token);
        Task<PaymentSession> CompleteSessionAsync(string token, string transactionId, string bankReference = null);
        Task<PaymentSession> FailSessionAsync(string token, string errorMessage);
        Task CleanupExpiredSessionsAsync();
    }
}
