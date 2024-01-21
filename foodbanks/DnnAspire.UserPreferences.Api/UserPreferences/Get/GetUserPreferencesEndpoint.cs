using DnnAspire.UserPreferences.Api.Data;

namespace DnnAspire.UserPreferences.Api.UserPreferences.Get;

public static class GetUserPreferencesEndpoint
{
    public static IEndpointRouteBuilder MapGetUserPreferencesEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/userpreferences/{userId}", async (GetUserPreferencesHandler handler, [FromRoute] Guid userId) =>
        {
            var userPreferences = await handler.Handle(userId);
            return Results.Ok(userPreferences);
        })
            .WithName(nameof(GetUserPreferencesEndpoint))
            .WithOpenApi()
            .Produces<UserPreference>();

        return builder;
    }
}