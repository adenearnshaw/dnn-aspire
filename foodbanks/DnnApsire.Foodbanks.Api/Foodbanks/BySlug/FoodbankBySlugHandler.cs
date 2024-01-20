namespace DnnApsire.Foodbanks.Api.Foodbanks.ByPostcode;

public class FoodbankBySlugHandler(GiveFoodApiClient apiClient)
{
    public async Task<Foodbank> Handle(string slug) 
        => await apiClient.FoodbankBySlug(slug);
}
