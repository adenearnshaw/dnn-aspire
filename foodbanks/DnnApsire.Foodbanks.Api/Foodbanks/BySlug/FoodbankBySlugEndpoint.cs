namespace DnnAspire.Foodbanks.Api.Foodbanks.ByPostcode;

public static class FoodbankBySlugEndpoint
{
    public static IEndpointRouteBuilder MapFoodbankBySlugEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/foodbank/{slug}", async (FoodbankBySlugHandler handler, [FromRoute] string slug) =>
        {
            var foodbank = await handler.Handle(slug);
            return Results.Ok(foodbank);
        })
            .WithName(nameof(FoodbankBySlugEndpoint))
            .WithOpenApi()
            .Produces<Foodbank>();

        return builder;
    }
}
