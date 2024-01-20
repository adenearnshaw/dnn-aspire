using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace DnnAspire.Foodbanks.Web.Configuration;

public static class ConfigureAuth
{
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(opts =>
        {
            opts.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opts.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddOpenIdConnect("oidc", options =>
        {
            options.Authority = "https://localhost:7001/";
            options.ClientId = "interactive";
            options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
            options.ResponseType = "code";
            options.SaveTokens = true;
            options.GetClaimsFromUserInfoEndpoint = true;
            options.UseTokenLifetime = false;
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.TokenValidationParameters = new TokenValidationParameters { NameClaimType = "name" };

            options.Events = new OpenIdConnectEvents
            {
                OnAccessDenied = context =>
                {
                    context.HandleResponse();
                    context.Response.Redirect("/");
                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }

}
