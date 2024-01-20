using DnnAspire.UserPreferences.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace DnnAspire.UserPreferences.Api.UserPreferences.Save;

public static class SaveUserPreferencesEndpoint
{
    public static IEndpointRouteBuilder MapSaveUserPreferencesEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/userpreferences/{userId}", async (SaveUserPreferencesHandler handler, [FromBody] UserPreference userPreference) =>
        {
            var savedUserPreference = await handler.Handle(userPreference);
            return Results.Ok(savedUserPreference);
        })
            .WithName(nameof(SaveUserPreferencesEndpoint))
            .WithOpenApi()
            .Produces<UserPreference>();

        return builder;
    }
}
