using AspNetCore.ReCaptcha;
using Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Services.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Areas.Identity
{
    public class CustomPageModel : PageModel
    {
        private readonly IReCaptchaService _reCaptchaService;
        private readonly IConfiguration _configuration;
        protected Dictionary<string, string> sharedRes;
        public CustomPageModel(IConfiguration configuration, IReCaptchaService reCaptchaService)
        {
            _configuration = configuration;
            _reCaptchaService = reCaptchaService;

        }

        public CustomPageModel()
        {

        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext ctx)
        {
            var currentLg = ctx.RouteData.Values["lang"].ToString();
            var result = GetCachedResource(currentLg);
            ViewData["Shared"] = result.ToDictionary(x => x.KeyName, x => x.KeyValue);
            sharedRes = (Dictionary<string, string>)ViewData["Shared"];
        }

        public string GetResource(string key)
        {
            return sharedRes.CheckKey(key);
        }

        public List<Localization> GetCachedResource(string lang)
        {
            List<Localization> resource;

            var services = this.HttpContext.RequestServices;

            var cache = (IMemoryCache)services.GetService(typeof(IMemoryCache));

            if (!cache.TryGetValue("Shared", out resource))
            {
                var localizations = (ILocalizationsService)services.GetService(typeof(ILocalizationsService));
                resource = localizations.GetTokensByResKey(ResourceKeys.Shared);

                //= dbResult.ToDictionary(x => x.KeyName, x => x.KeyValue);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(7));
                cache.Set("Shared", resource, cacheEntryOptions);
            }

            var returnedRes = resource.Where(x => x.Language.Code == lang).Distinct().ToList();

            if (returnedRes.Count() == 0)
            {
                returnedRes = resource.Where(x => x.Language.Code == "sq").Distinct().ToList();
            }
            return returnedRes;
        }
    }
}
