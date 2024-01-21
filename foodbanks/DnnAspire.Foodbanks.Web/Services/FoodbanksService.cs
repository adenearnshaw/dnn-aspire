using DnnAspire.Foodbanks.Web.Models;

namespace DnnAspire.Foodbanks.Web.Services;

public class FoodbanksService(IHttpClientFactory clientFactory)
{
    public async Task<List<FoodbankSearchModel>> SearchFoodbanksByPostcode(string postcode)
    {
        var client = clientFactory.CreateClient("foodbankClient");

        var request = new HttpRequestMessage(HttpMethod.Get, $"/foodbanks/postcode/{postcode}");

        var response = await client.SendAsync(request);

        var searchResults = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<FoodbankSearchModel>>() ?? []
            : [];

        return searchResults;
    }

    public async Task<FoodbankModel?> GetFoodbankBySlug(string slug)
    {
        var client = clientFactory.CreateClient("foodbankClient");

        var request = new HttpRequestMessage(HttpMethod.Get, $"/foodbank/{slug}");

        var response = await client.SendAsync(request);

        var foodbank = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<FoodbankModel>()
            : default;

        return foodbank;
    }
}
