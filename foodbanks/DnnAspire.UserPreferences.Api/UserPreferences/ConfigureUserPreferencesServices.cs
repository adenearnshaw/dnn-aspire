using DnnAspire.UserPreferences.Api.UserPreferences.Get;
using DnnAspire.UserPreferences.Api.UserPreferences.Save;

namespace DnnAspire.UserPreferences.Api.UserPreferences;

public static class ConfigureUserPreferencesServices
{
    public static IServiceCollection AddUserPreferencesServices(this IServiceCollection services)
    {
        services.AddTransient<GetUserPreferencesHandler>();
        services.AddTransient<SaveUserPreferencesHandler>();

        return services;
    }

    public static IEndpointRouteBuilder MapUserPreferencesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGetUserPreferencesEndpoint();
        endpoints.MapSaveUserPreferencesEndpoint();

        return endpoints;
    }
}
