// Create this as a new file: Filters/ApiKeyAuthAttribute.cs

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using System.Threading.Tasks;
using Web.Filters;
using static Web.Controllers.ProductController;

namespace Web.Filters
{
    public class ApiKeyAuthAttribute : ActionFilterAttribute
    {
        private const string ApiKeyHeaderName = "X-API-Key";
        private const string ApiKeyQueryParam = "apikey";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var configuration = context.HttpContext.RequestServices
                .GetRequiredService<IConfiguration>();

            var logger = context.HttpContext.RequestServices
                .GetRequiredService<ILogger<ApiKeyAuthAttribute>>();

            var validApiKey = configuration["ApiSettings:N8nApiKey"];

            if (string.IsNullOrEmpty(validApiKey))
            {
                logger.LogError("API key not configured in appsettings");
                context.Result = new UnauthorizedObjectResult(new
                {
                    success = false,
                    message = "API authentication not configured"
                });
                return;
            }

            // Check header first, then query parameter
            string providedApiKey = null;

            if (context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var headerValue))
            {
                providedApiKey = headerValue.FirstOrDefault();
            }
            else if (context.HttpContext.Request.Query.TryGetValue(ApiKeyQueryParam, out var queryValue))
            {
                providedApiKey = queryValue.FirstOrDefault();
            }

            if (string.IsNullOrEmpty(providedApiKey))
            {
                logger.LogWarning("API key missing from request");
                context.Result = new UnauthorizedObjectResult(new
                {
                    success = false,
                    message = "API key required. Include in X-API-Key header or apikey query parameter"
                });
                return;
            }

            if (validApiKey != providedApiKey)
            {
                logger.LogWarning("Invalid API key provided: {ProvidedKey}",
                    providedApiKey?.Substring(0, Math.Min(10, providedApiKey.Length)) + "...");
                context.Result = new UnauthorizedObjectResult(new
                {
                    success = false,
                    message = "Invalid API key"
                });
                return;
            }

            logger.LogInformation("Valid API key authenticated");
            base.OnActionExecuting(context);
        }
    }
}

// Alternative: Create a middleware approach (optional)
namespace Web.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiKeyMiddleware> _logger;
        private const string ApiKeyHeaderName = "X-API-Key";

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<ApiKeyMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Only apply to API routes
            if (!context.Request.Path.StartsWithSegments("/api"))
            {
                await _next(context);
                return;
            }

            var validApiKey = _configuration["ApiSettings:N8nApiKey"];

            if (string.IsNullOrEmpty(validApiKey))
            {
                await RespondWithError(context, "API authentication not configured", 500);
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKey))
            {
                await RespondWithError(context, "API key required in X-API-Key header", 401);
                return;
            }

            if (validApiKey != providedApiKey)
            {
                _logger.LogWarning("Invalid API key attempt from {IP}", context.Connection.RemoteIpAddress);
                await RespondWithError(context, "Invalid API key", 401);
                return;
            }

            await _next(context);
        }

        private async Task RespondWithError(HttpContext context, string message, int statusCode)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new { success = false, message = message };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}