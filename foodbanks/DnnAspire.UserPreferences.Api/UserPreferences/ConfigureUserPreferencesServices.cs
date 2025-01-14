using DnnAspire.UserPreferences.Api.UserPreferences.Clear;
using DnnAspire.UserPreferences.Api.UserPreferences.Get;
using DnnAspire.UserPreferences.Api.UserPreferences.Save;

namespace DnnAspire.UserPreferences.Api.UserPreferences;

public static class ConfigureUserPreferencesServices
{
    public static IHostApplicationBuilder AddUserPreferencesServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient<GetUserPreferencesHandler>();
        builder.Services.AddTransient<SaveUserPreferencesHandler>();

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddTransient<ClearUserPreferencesHandler>();
        }
        
        return builder;
    }

    public static WebApplication MapUserPreferencesEndpoints(this WebApplication app)
    {
        app.MapGetUserPreferencesEndpoint();
        app.MapSaveUserPreferencesEndpoint();

        if (app.Environment.IsDevelopment())
        {
            app.MapClearUserPreferencesEndpoint();
        }
        
        return app;
    }
}
