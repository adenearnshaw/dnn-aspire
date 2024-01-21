using DnnAspire.Foodbanks.Web.Components;
using DnnAspire.Foodbanks.Web.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<FoodbanksService>();
builder.Services.AddTransient<UserPreferencesService>();

builder.Services.AddHttpClient("foodbankClient", opts =>
{
    opts.BaseAddress = new Uri("https://localhost:7018");
});

builder.Services.AddHttpClient("userPreferencesClient", opts =>
{
    opts.BaseAddress = new Uri("https://localhost:7201");
});

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["Syncfusion:ApiKey"]);
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
