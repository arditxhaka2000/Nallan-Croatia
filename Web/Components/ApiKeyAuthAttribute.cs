// Create this as a new file: Filters/ApiKeyAuthAttribute.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Web.Filters;
using static Web.Controllers.ProductController;

namespace Web.Filters
{
    public class ApiKeyAuthAttribute : ActionFilterAttribute
    {
        private const string ApiKeyHeaderName = "X-API-Key";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var configuration = context.HttpContext.RequestServices
                .GetRequiredService<IConfiguration>();

            var validApiKey = configuration["ApiSettings:N8nApiKey"];

            if (string.IsNullOrEmpty(validApiKey))
            {
                context.Result = new UnauthorizedObjectResult(new
                {
                    success = false,
                    message = "API key not configured"
                });
                return;
            }

            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKey))
            {
                context.Result = new UnauthorizedObjectResult(new
                {
                    success = false,
                    message = "API key missing"
                });
                return;
            }

            if (validApiKey != providedApiKey)
            {
                context.Result = new UnauthorizedObjectResult(new
                {
                    success = false,
                    message = "Invalid API key"
                });
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}