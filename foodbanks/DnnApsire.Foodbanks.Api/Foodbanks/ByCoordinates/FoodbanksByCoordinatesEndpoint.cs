namespace DnnApsire.Foodbanks.Api.Foodbanks.ByPostcode;

public static class FoodbanksByCoordinatesEndpoint
{
    public static IEndpointRouteBuilder MapFoodbanksByCoordinatesEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/foodbanks/coordinates", async (FoodbanksByCoordinatesHandler handler, [FromQuery] string latitude, [FromQuery] string longitude) =>
        {
            var foodbanks = await handler.Handle(latitude, longitude);
            return Results.Ok(foodbanks);
        })
            .WithName(nameof(FoodbanksByCoordinatesEndpoint))
            .WithOpenApi()
            .Produces<List<Foodbank>>();

        return builder;
    }
}
