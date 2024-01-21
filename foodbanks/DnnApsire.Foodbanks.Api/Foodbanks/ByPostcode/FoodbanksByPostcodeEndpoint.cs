namespace DnnAspire.Foodbanks.Api.Foodbanks.ByPostcode;

public static class FoodbanksByPostcodeEndpoint
{
    public static IEndpointRouteBuilder MapFoodbanksByPostcodeEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/foodbanks/postcode/{postcode}", async (FoodbanksByPostcodeHandler handler, [FromRoute] string postcode) =>
        {
            var foodbanks = await handler.Handle(postcode);
            return Results.Ok(foodbanks);
        })
            .WithName(nameof(FoodbanksByPostcodeEndpoint))
            .WithOpenApi()
            .Produces<List<Foodbank>>();

        return builder;
    }
}
