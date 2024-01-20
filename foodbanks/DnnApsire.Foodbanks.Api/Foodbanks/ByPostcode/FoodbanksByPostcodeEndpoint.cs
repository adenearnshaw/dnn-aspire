namespace DnnApsire.Foodbanks.Api.Foodbanks.ByPostcode;

public static class FoodbanksByPostcodeEndpoint
{
    public static IEndpointRouteBuilder MapFoodbanksByPostcodeEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/foodbanks/postcode", async (FoodbanksByPostcodeHandler handler, [FromQuery] string postcode) =>
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
