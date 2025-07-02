using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using System.Linq;
using Web.Components;

namespace Web.Components
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SecurityMiddleware> _logger;
        private readonly HashSet<string> _blockedIPs;
        private readonly Dictionary<string, DateTime> _requestCounts;
        private readonly object _lockObject = new object();

        public SecurityMiddleware(RequestDelegate next, ILogger<SecurityMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _blockedIPs = new HashSet<string>();
            _requestCounts = new Dictionary<string, DateTime>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var clientIP = GetClientIP(context);

            // Check if IP is blocked
            if (_blockedIPs.Contains(clientIP))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Access Denied");
                return;
            }

            // Rate limiting per IP
            if (IsRateLimited(clientIP))
            {
                _logger.LogWarning("Rate limit exceeded for IP: {IP}", clientIP);
                context.Response.StatusCode = 429;
                await context.Response.WriteAsync("Too Many Requests");
                return;
            }

            // Payment endpoint additional security
            if (context.Request.Path.StartsWithSegments("/payment"))
            {
                if (!await ValidatePaymentRequest(context))
                {
                    return;
                }
            }

            // Add request correlation ID for tracking
            var correlationId = GenerateCorrelationId();
            context.Items["CorrelationId"] = correlationId;
            context.Response.Headers.Add("X-Correlation-ID", correlationId);

            await _next(context);
        }

        private async Task<bool> ValidatePaymentRequest(HttpContext context)
        {
            try
            {
                // Additional validation for payment requests
                if (context.Request.Method == "POST")
                {
                    // Check content type
                    if (!context.Request.ContentType?.Contains("application/x-www-form-urlencoded") == true &&
                        !context.Request.ContentType?.Contains("multipart/form-data") == true)
                    {
                        _logger.LogWarning("Invalid content type for payment request from IP: {IP}", GetClientIP(context));
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid Content Type");
                        return false;
                    }

                    // Check for required headers
                    if (!context.Request.Headers.ContainsKey("Referer") &&
                        context.Request.Path != "/payment/callback") // Bank callback won't have referer
                    {
                        _logger.LogWarning("Missing referer header for payment request from IP: {IP}", GetClientIP(context));
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Bad Request");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating payment request");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Internal Server Error");
                return false;
            }
        }

        private string GetClientIP(HttpContext context)
        {
            // Check for forwarded headers (behind proxy/load balancer)
            var forwardedFor = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(forwardedFor))
            {
                return forwardedFor.Split(',')[0].Trim();
            }

            var realIP = context.Request.Headers["X-Real-IP"].FirstOrDefault();
            if (!string.IsNullOrEmpty(realIP))
            {
                return realIP;
            }

            return context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        }

        private bool IsRateLimited(string clientIP)
        {
            lock (_lockObject)
            {
                var now = DateTime.UtcNow;
                var key = $"{clientIP}_{now:yyyy-MM-dd-HH-mm}"; // Per minute rate limiting

                // Clean old entries
                var oldKeys = _requestCounts.Where(kvp => kvp.Value < now.AddMinutes(-5)).Select(kvp => kvp.Key).ToList();
                foreach (var oldKey in oldKeys)
                {
                    _requestCounts.Remove(oldKey);
                }

                // Check current minute requests
                var currentMinuteKeys = _requestCounts.Keys.Where(k => k.StartsWith($"{clientIP}_{now:yyyy-MM-dd-HH-mm}")).Count();

                if (currentMinuteKeys >= 10) // 10 requests per minute per IP
                {
                    return true;
                }

                _requestCounts[key] = now;
                return false;
            }
        }

        private string GenerateCorrelationId()
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[8];
            rng.GetBytes(bytes);
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }
    }

    // Custom exception handling middleware
    public class SecureExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SecureExceptionMiddleware> _logger;

        public SecureExceptionMiddleware(RequestDelegate next, ILogger<SecureExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the full exception securely
                var correlationId = context.Items["CorrelationId"]?.ToString() ?? "unknown";

                _logger.LogError(ex, "Unhandled exception occurred. CorrelationId: {CorrelationId}, Path: {Path}",
                    correlationId, context.Request.Path);

                // Return generic error response (never expose internal details)
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = "An internal server error occurred",
                    correlationId = correlationId,
                    timestamp = DateTime.UtcNow.ToString("O")
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

    // Security headers middleware
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Remove information disclosure headers
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Remove("Server");
                context.Response.Headers.Remove("X-Powered-By");
                context.Response.Headers.Remove("X-AspNetMvc-Version");
                context.Response.Headers.Remove("X-AspNet-Version");

                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}

// Extension method to register middleware
namespace Microsoft.AspNetCore.Builder
{
    public static class SecurityMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityMiddleware(this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<SecurityHeadersMiddleware>()
                .UseMiddleware<SecurityMiddleware>()
                .UseMiddleware<SecureExceptionMiddleware>();
        }
    }
}
