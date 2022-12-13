using LearningPortal.Mediator.Mediators.UserMediators;
using MediatR;
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
        private readonly IMediator _mediator;

        public LoginModel(IMediator mediator) => _mediator = mediator;

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

                var identity = googleUser.FindFirst(ClaimTypes.NameIdentifier)!.Value;

                var isRegistered = await _mediator.Send(new IsUserIdentityRegisteredRequest(identity));

                if(isRegistered.HasStatusCode200 && isRegistered.ContentAs<bool>() == false)
                {
                    await _mediator.Send(new InsertUserRequest(identity));
                    // TODO: After Inserting User, Direct User to page where we will collect their Preferred Name and confirm the name we receive from Identity
                }
                // TODO: Else if statusCode 200 && IsRegistered == true, go to user home page
             
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(googleUser), authProperties);
            }

            return LocalRedirect("/");
        }
    }
}
