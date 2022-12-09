using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LearningPortal.BlazorServerApp.Pages.Identity
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public IActionResult OnGetAsync(string? returnUrl = null)
        {
            string provider = "Google";
            
            // Request a redirect to the external login provider.
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Page("./Login", pageHandler: "Callback", values: new { returnUrl })
            };

            return new ChallengeResult(provider, authenticationProperties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string? returnUrl = null, string? remoteError = null)
        {
            // Get the information about the user from the external login provider
            var googleUser = User.Identities.FirstOrDefault();

            if (googleUser?.IsAuthenticated ?? false)
            {
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = Request.Host.Value                   
                };
             
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(googleUser), authProperties);
            }

            //TODO: If no user exists in Users table then direct to Login Page - else direct to Home Page

            return LocalRedirect("/");
        }
    }
}