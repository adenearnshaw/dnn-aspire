namespace DnnAspire.UserPreferences.Api.UserPreferences.Clear;

public static class ClearUserPreferencesEndpoint
{
    public static IEndpointRouteBuilder MapClearUserPreferencesEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/userpreferences/remove-all", async (ClearUserPreferencesHandler handler) =>
            {
                await handler.Handle();
                return Results.Ok();
            })
            .WithName(nameof(ClearUserPreferencesEndpoint))
            .WithOpenApi();

        return builder;
    }
}
