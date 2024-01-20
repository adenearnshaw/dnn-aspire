namespace DnnApsire.Foodbanks.Api.Foodbanks.ByPostcode;

public class FoodbanksByPostcodeHandler(GiveFoodApiClient apiClient)
{
    public async Task<List<Foodbank>> Handle(string postcode) 
        => await apiClient.FoodbanksSearchByPostcode(postcode);
}
