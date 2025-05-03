using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web.Infrastructure;
using Microsoft.AspNetCore.Localization;
using Data;
using Services.Users;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Services.Localizations;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Http;
using Web.Providers;
using Microsoft.Extensions.Configuration;


/*
 
 @inject SignInManager<Data.AppUser> SignInManager
@inject UserManager<Data.AppUser> UserManager
 
 */
namespace Web.Areas.Identity.Pages.Account
{
    //[AllowAnonymous]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    //[ValidateReCaptcha]
    public class LoginModel : PageModel
    {
        private readonly UserManager<Data.AppUser> _userManager;
        private readonly SignInManager<Data.AppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IUsersService _usersService;
        private readonly IConfiguration _configuration;

        public LoginModel(SignInManager<Data.AppUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<Data.AppUser> userManager, IUsersService usersService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _usersService = usersService;
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }



        public async Task OnGetAsync(string returnUrl = null)
        {
            var feature = HttpContext.Features.Get<IRequestCultureFeature>();
            var _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext ctx)
        {
            //base.OnActionExecuting(context);

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

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var token = HttpContext.Request.Form["g-recaptcha-response"];
                RecaptchaV3Helper recaptchaV3Helper = new RecaptchaV3Helper(_configuration);
                var captchaResult = recaptchaV3Helper.IsReCaptchaValid(token).Result;
                //var captchaResult = isReCaptchaValid().Result;
                if (!captchaResult)
                {
                    ModelState.AddModelError("", "PleaseVerifyrecaptcha");
                    return Page();
                }
                AppUser user = _usersService.FindByUserName(Input.userName);

                if (user == null)
                {
                    ModelState.AddModelError("", "LOGIN_INVALID_ATTEMPT");
                    return Page();
                }

                if (!user.active)
                {
                    ModelState.AddModelError("", "This user is blocked");
                    return Page();
                }
                //if (!user.EmailConfirmed)
                //{
                //    _logger.LogWarning("Emaild are't account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
                //if (!user.EmailConfirmed)
                //{
                //    _logger.LogWarning("Emaild are't account locked out.");
                //    return RedirectToPage("./Lockout");
                //}

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.userName, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                if (result.IsNotAllowed)
                {

                    ModelState.AddModelError("", "User account is not allow to login.");
                    return Page();
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
    public class InputModel
    {
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
