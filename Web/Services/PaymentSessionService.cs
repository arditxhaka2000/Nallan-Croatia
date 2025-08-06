using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Services.CorvusPayments
{
    public class PaymentSessionService : IPaymentSessionService
    {
        private readonly IMemoryCache _cache;

        public PaymentSessionService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<PaymentSession> CreateSessionAsync(string orderId, decimal amount, string userId, int timeoutMinutes)
        {
            var session = new PaymentSession
            {
                Token = Guid.NewGuid().ToString(),
                OrderId = orderId,
                Amount = amount,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(timeoutMinutes)
            };

            var cacheKey = $"payment_session_{session.Token}";
            _cache.Set(cacheKey, session, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = session.ExpiresAt,
                Size = 1
            });

            return Task.FromResult(session);
        }

        public Task<PaymentSession> GetSessionAsync(string token)
        {
            var cacheKey = $"payment_session_{token}";
            _cache.TryGetValue(cacheKey, out PaymentSession session);
            return Task.FromResult(session);
        }

        public Task<PaymentSession> GetSessionByOrderIdAsync(string orderId)
        {
            // Simple implementation - in production you might want a proper reverse lookup
            // For now, we'll return null and handle this case in the controller
            return Task.FromResult<PaymentSession>(null);
        }

        public Task InvalidateSessionAsync(string token)
        {
            var cacheKey = $"payment_session_{token}";
            _cache.Remove(cacheKey);
            return Task.CompletedTask;
        }
    }
}