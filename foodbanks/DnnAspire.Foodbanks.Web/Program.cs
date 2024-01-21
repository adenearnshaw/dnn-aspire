using DnnAspire.Foodbanks.Web.Components;
using DnnAspire.Foodbanks.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<FoodbanksService>();
builder.Services.AddTransient<UserPreferencesService>();

builder.Services.AddHttpClient("foodbankClient", opts =>
{
    opts.BaseAddress = new Uri("https://foodbanksapi");
});

builder.Services.AddHttpClient("userPreferencesClient", opts =>
{
    opts.BaseAddress = new Uri("https://userpreferencesapi");
});

builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opts.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(opts =>
{
    builder.Configuration.GetSection("Services:Idp").Bind(opts);

    opts.RequireHttpsMetadata = false;

    opts.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opts.ResponseType = OpenIdConnectResponseType.Code;

    opts.SaveTokens = true;
    opts.GetClaimsFromUserInfoEndpoint = true;
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "name"
    };
});

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["Syncfusion:ApiKey"]);
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.

JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();

app.Run();
