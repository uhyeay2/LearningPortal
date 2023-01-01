using LearningPortal.Data;
using LearningPortal.Data.Abstractions.Interfaces;
using LearningPortal.Domain.Interfaces;
using LearningPortal.Mediator;
using LearningPortal.Mediator.Configurations;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LearningPortal.BlazorServerApp.Configurations
{
    public static class ServiceDependencies
    {
        public static WebApplicationBuilder InjectServices(this WebApplicationBuilder builder)
        {
            // Blazor
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Google Auth
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
                options.Events.OnRedirectToAuthorizationEndpoint = context =>
                {
                    context.Response.Redirect(context.RedirectUri + "&prompt=consent");
                    return Task.CompletedTask;
                };
            });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<HttpContextAccessor>();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<HttpClient>();

            builder.Services.InjectMediator();

            return builder;
        }
    }
}
