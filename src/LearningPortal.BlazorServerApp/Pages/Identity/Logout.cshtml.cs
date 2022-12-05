using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningPortal.BlazorServerApp.Pages.Identity
{
    public class LogoutModel : PageModel
    {
        public string ReturnUrl { get; private set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync( string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception)
            {
            }

            return LocalRedirect("/");
        }
    }
}
