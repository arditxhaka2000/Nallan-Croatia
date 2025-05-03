using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AspNetCore.ReCaptcha;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Services.Localizations;
using SimpleEmailApp.Services.EmailService;
using Web.Infrastructure;
using Web.Models.EmailConfig;
using Web.Providers;

namespace Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class ForgotPasswordModel : CustomPageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IReCaptchaService _reCaptchaService;
        private readonly IConfiguration _configuration;
        public ForgotPasswordModel(UserManager<AppUser> userManager, IEmailService emailService, IConfiguration configuration, IReCaptchaService reCaptchaService) : base(configuration, reCaptchaService)
        {
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
            _reCaptchaService = reCaptchaService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [RegularExpression(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,7}\b")]
            public string Email { get; set; }
        }

        //public override void OnPageHandlerExecuting(PageHandlerExecutingContext ctx)
        //{
        //    var currentLg = ctx.RouteData.Values["lang"].ToString();
        //    var result = GetCachedResource(currentLg);
        //    ViewData["Shared"] = result.ToDictionary(x => x.KeyName, x => x.KeyValue);
        //}
        //public List<Localization> GetCachedResource(string lang)
        //{
        //    List<Localization> resource;

        //    var services = this.HttpContext.RequestServices;

        //    var cache = (IMemoryCache)services.GetService(typeof(IMemoryCache));

        //    if (!cache.TryGetValue("Shared", out resource))
        //    {
        //        var localizations = (ILocalizationsService)services.GetService(typeof(ILocalizationsService));
        //        resource = localizations.GetTokensByResKey(ResourceKeys.Shared);

        //        //= dbResult.ToDictionary(x => x.KeyName, x => x.KeyValue);

        //        var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(60));
        //        cache.Set("Shared", resource, cacheEntryOptions);
        //    }

        //    return resource.Where(x => x.Language.Code == lang).ToList();
        //}


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var token = HttpContext.Request.Form["g-recaptcha-response"];
                RecaptchaV3Helper recaptchaV3Helper = new RecaptchaV3Helper(_configuration);
                var captchaResult = recaptchaV3Helper.IsReCaptchaValid(token).Result;
                if (!captchaResult)
                {
                    ModelState.AddModelError("", GetResource("PleaseVerifyrecaptcha"));
                    return Page();
                }
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code, email = Input.Email },
                    protocol: Request.Scheme);

                var sent = SendEmail(new EmailConfiguration
                {
                    ToAsBcc = new List<string>() { Input.Email },
                    dynamictext = new string[] { callbackUrl },
                    Template = "ResetPassword.html"
                }
                        );
                if (!sent)
                {
                    return RedirectToPage("./FailedToSendEmail");

                }
                return RedirectToPage("./ForgotPasswordConfirmation");
            }
            return Page();
        }
        public bool SendEmail(EmailConfiguration e)
        {
            e.Body = System.IO.File.ReadAllText(System.IO.Path.Combine("wwwroot", "html/") + e.Template);
            if (e.dynamictext != null)
            {
                for (int i = 0; i < e.dynamictext.Length; i++)
                {
                    e.Body = e.Body.Replace("{" + i + "}", e.dynamictext[i]);
                }
            }
            return _emailService.SendEmail(e);
        }
    }
}
