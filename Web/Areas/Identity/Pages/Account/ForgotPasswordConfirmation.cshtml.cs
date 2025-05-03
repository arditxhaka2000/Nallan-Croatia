// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Services.Localizations;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Infrastructure;

namespace Web.Areas.Identity.Pages.Account
{
    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [AllowAnonymous]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class ForgotPasswordConfirmation : PageModel
    {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public void OnGet()
        {
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext ctx)
        {
            var currentLg = ctx.RouteData.Values["lang"].ToString();
            var result = GetCachedResource(currentLg);
            ViewData["Shared"] = result.ToDictionary(x => x.KeyName, x => x.KeyValue);
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

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(60));
                cache.Set("Shared", resource, cacheEntryOptions);
            }

            return resource.Where(x => x.Language.Code == lang).ToList();
        }
    }
}
