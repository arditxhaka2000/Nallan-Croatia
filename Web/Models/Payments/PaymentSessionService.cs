using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Web.Models.Payment;
using Web.Models.TebBank;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Web.Models.Payments
{
    public class PaymentSessionService : IPaymentSessionService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<PaymentSessionService> _logger;
        private readonly TebBankSettings _settings;
        private const string CACHE_KEY_PREFIX = "payment_session_";
        private const string USER_SESSIONS_PREFIX = "user_sessions_";

        public PaymentSessionService(
            IMemoryCache cache,
            ILogger<PaymentSessionService> logger,
            IOptions<TebBankSettings> settings)
        {
            _cache = cache;
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task<PaymentSession> CreateSessionAsync(string orderId, decimal amount, string userId, int? timeoutMinutes = null)
        {
            await Task.CompletedTask;

            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(orderId))
                    throw new ArgumentException("Order ID cannot be empty", nameof(orderId));

                if (amount <= 0)
                    throw new ArgumentException("Amount must be greater than zero", nameof(amount));

                if (string.IsNullOrWhiteSpace(userId))
                    throw new ArgumentException("User ID cannot be empty", nameof(userId));

                // Check amount limits
                if (amount < _settings.MinAmount || amount > _settings.MaxAmount)
                    throw new ArgumentException($"Amount must be between {_settings.MinAmount} and {_settings.MaxAmount}", nameof(amount));

                // Generate secure token
                var token = GenerateSecureToken(orderId, amount, userId);

                // Create session
                var session = PaymentSession.Create(
                    token,
                    orderId,
                    amount,
                    userId,
                    timeoutMinutes ?? _settings.SessionTimeoutMinutes);

                // Store in cache with PROPER SIZE
                var cacheKey = CACHE_KEY_PREFIX + token;
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = session.ExpiresAt,
                    Priority = CacheItemPriority.High,
                    Size = 1 
                };

                _cache.Set(cacheKey, session, cacheOptions);

                // Track user sessions for cleanup
                TrackUserSession(userId, token, session.ExpiresAt);

                _logger.LogInformation("Payment session created for order {OrderId}, user {UserId}, expires at {ExpiresAt}",
                    SanitizeOrderId(orderId), GetHashedUserId(userId), session.ExpiresAt);

                return session;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating payment session for order {OrderId}", SanitizeOrderId(orderId));
                throw;
            }
        }
        public async Task<PaymentSession?> GetSessionAsync(string token)
        {
            await Task.CompletedTask;

            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return null;

                var cacheKey = CACHE_KEY_PREFIX + token;

                if (_cache.TryGetValue(cacheKey, out PaymentSession? session))
                {
                    // Check if session is expired
                    if (session.IsExpired)
                    {
                        await InvalidateSessionAsync(token);
                        return null;
                    }

                    return session;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payment session");
                return null;
            }
        }

        public async Task<bool> ValidateSessionAsync(string token, string orderId, decimal amount)
        {
            try
            {
                var session = await GetSessionAsync(token);
                return session?.ValidateForPayment(orderId, amount) == true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating payment session");
                return false;
            }
        }

        public async Task InvalidateSessionAsync(string token)
        {
            await Task.CompletedTask;

            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return;

                var cacheKey = CACHE_KEY_PREFIX + token;

                // Get session before removing to clean up user tracking
                if (_cache.TryGetValue(cacheKey, out PaymentSession? session))
                {
                    session.MarkAsExpired();
                    RemoveFromUserTracking(session.UserId, token);
                }

                _cache.Remove(cacheKey);

                _logger.LogDebug("Payment session invalidated: {Token}", SanitizeToken(token));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating payment session");
            }
        }

        public async Task<PaymentSession?> CompleteSessionAsync(string token, string transactionId, string? bankReference = null)
        {
            try
            {
                var session = await GetSessionAsync(token);
                if (session == null)
                {
                    _logger.LogWarning("Attempted to complete non-existent payment session");
                    return null;
                }

                session.MarkAsCompleted(transactionId, bankReference);

                // Update in cache with extended expiration for audit purposes
                var cacheKey = CACHE_KEY_PREFIX + token;
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.UtcNow.AddHours(24), // Keep completed sessions for 24 hours
                    Priority = CacheItemPriority.Low,
                    Size = 1 // ✅ FIXED: Always specify size
                };

                _cache.Set(cacheKey, session, cacheOptions);

                _logger.LogInformation("Payment session completed for order {OrderId}, transaction {TransactionId}",
                    SanitizeOrderId(session.OrderId), SanitizeTransactionId(transactionId));

                return session;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing payment session");
                return null;
            }
        }
        public async Task<PaymentSession?> FailSessionAsync(string token, string errorMessage)
        {
            try
            {
                var session = await GetSessionAsync(token);
                if (session == null)
                {
                    _logger.LogWarning("Attempted to fail non-existent payment session");
                    return null;
                }

                session.MarkAsFailed(errorMessage);

                // Update in cache
                var cacheKey = CACHE_KEY_PREFIX + token;
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.UtcNow.AddHours(1), // Keep failed sessions for 1 hour
                    Priority = CacheItemPriority.Low,
                    Size = 1 // ✅ FIXED: Always specify size
                };

                _cache.Set(cacheKey, session, cacheOptions);

                _logger.LogWarning("Payment session failed for order {OrderId}: {ErrorMessage}",
                    SanitizeOrderId(session.OrderId), errorMessage);

                return session;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error failing payment session");
                return null;
            }
        }
        public async Task CleanupExpiredSessionsAsync()
        {
            await Task.CompletedTask;

            try
            {
                // This is a simple implementation. In production, you might want to use a background service
                // and iterate through all cached sessions to clean them up.
                // For now, expired sessions are cleaned up when accessed.

                _logger.LogDebug("Expired session cleanup completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during expired session cleanup");
            }
        }

        // Helper methods
        private string GenerateSecureToken(string orderId, decimal amount, string userId)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var nonce = GenerateNonce();
            var data = $"{orderId}|{amount}|{userId}|{timestamp}|{nonce}";

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes($"PaymentSession_{Environment.MachineName}"));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

            return Convert.ToBase64String(hash)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "")
                .Substring(0, 32); // Take first 32 characters for reasonable token length
        }

        private string GenerateNonce()
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[16];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes).Replace("=", "");
        }

        private void TrackUserSession(string userId, string token, DateTime expiresAt)
        {
            try
            {
                var userSessionsKey = USER_SESSIONS_PREFIX + GetHashedUserId(userId);

                if (!_cache.TryGetValue(userSessionsKey, out Dictionary<string, DateTime>? userSessions))
                {
                    userSessions = new Dictionary<string, DateTime>();
                }

                userSessions[token] = expiresAt;

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = expiresAt.AddHours(1),
                    Priority = CacheItemPriority.Low,
                    Size = 1 
                };

                _cache.Set(userSessionsKey, userSessions, cacheOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error tracking user session");
            }
        }

        private void RemoveFromUserTracking(string userId, string token)
        {
            try
            {
                var userSessionsKey = USER_SESSIONS_PREFIX + GetHashedUserId(userId);

                if (_cache.TryGetValue(userSessionsKey, out Dictionary<string, DateTime>? userSessions))
                {
                    userSessions.Remove(token);

                    if (userSessions.Count == 0)
                    {
                        _cache.Remove(userSessionsKey);
                    }
                    else
                    {
                        _cache.Set(userSessionsKey, userSessions);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing from user session tracking");
            }
        }

        // Security helper methods for logging
        private string SanitizeOrderId(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return "empty";
            return orderId.Length > 8 ? $"{orderId[..4]}***{orderId[^4..]}" : "****";
        }

        private string SanitizeToken(string token)
        {
            if (string.IsNullOrEmpty(token)) return "empty";
            return token.Length > 8 ? $"{token[..4]}***{token[^4..]}" : "****";
        }

        private string SanitizeTransactionId(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId)) return "empty";
            return transactionId.Length > 8 ? $"{transactionId[..4]}***{transactionId[^4..]}" : "****";
        }

        private string GetHashedUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return "anonymous";

            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(userId));
            return Convert.ToHexString(hash)[..8];
        }
    }
}