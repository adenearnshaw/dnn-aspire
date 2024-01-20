using DnnAspire.Foodbanks.Api.Foodbanks.ByPostcode;

namespace DnnAspire.Foodbanks.Api.Foodbanks;

public static class ConfigureFoodbanksServices
{
    public static IServiceCollection AddFoodbanksServices(this IServiceCollection services)
    {
        services.AddTransient<GiveFoodApiClient>();
        services.AddTransient<FoodbanksByPostcodeHandler>();
        services.AddTransient<FoodbanksByCoordinatesHandler>();
        services.AddTransient<FoodbankBySlugHandler>();

        return services;
    }

    public static IEndpointRouteBuilder MapFoodbanksEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapFoodbanksByPostcodeEndpoint();
        endpoints.MapFoodbanksByCoordinatesEndpoint();
        endpoints.MapFoodbankBySlugEndpoint();

        return endpoints;
    }
}
