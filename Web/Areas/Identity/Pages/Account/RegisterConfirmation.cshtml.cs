using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Areas.Identity.Pages.Account
{

    public class RegisterConfirmationModel : PageModel
    {
        private readonly ILogger<RegisterConfirmationModel> _logger;

        public RegisterConfirmationModel(ILogger<RegisterConfirmationModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public IActionResult OnGet(string email, string returnUrl = null)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Index");
            }

            Email = email;
            ReturnUrl = returnUrl;

            // Optionally, check if the user needs to confirm their account
            DisplayConfirmAccountLink = false; // Set to true if you want to show a resend link
            _logger.LogInformation("User registration confirmation page accessed for email {Email}", Email);

            return Page();
        }
    }
}
