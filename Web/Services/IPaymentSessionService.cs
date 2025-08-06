using System;
using System.Threading.Tasks;

namespace Services.CorvusPayments
{
    public interface IPaymentSessionService
    {
        Task<PaymentSession> CreateSessionAsync(string orderId, decimal amount, string userId, int timeoutMinutes);
        Task<PaymentSession> GetSessionAsync(string token);
        Task<PaymentSession> GetSessionByOrderIdAsync(string orderId);
        Task InvalidateSessionAsync(string token);
    }

    public class PaymentSession
    {
        public string Token { get; set; } = "";
        public string OrderId { get; set; } = "";
        public decimal Amount { get; set; }
        public string UserId { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsExpired => DateTime.UtcNow > ExpiresAt;
        public bool IsValid => !string.IsNullOrEmpty(Token) && !string.IsNullOrEmpty(OrderId);
    }
}