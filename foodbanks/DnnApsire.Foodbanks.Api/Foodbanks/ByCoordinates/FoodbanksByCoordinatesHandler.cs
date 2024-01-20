namespace DnnApsire.Foodbanks.Api.Foodbanks.ByPostcode;

public class FoodbanksByCoordinatesHandler(GiveFoodApiClient apiClient)
{
    public async Task<List<Foodbank>> Handle(string latitude, string longitude)
    {
        var lat = Convert.ToDouble(latitude);
        var lng = Convert.ToDouble(longitude);

        return await apiClient.FoodbanksSearchByCoordinates(lat, lng);
    }
}
