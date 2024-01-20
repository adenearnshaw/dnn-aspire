using System.Text.Json;

namespace DnnAspire.Foodbanks.Api.Foodbanks;

public class GiveFoodApiClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public GiveFoodApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
        };
    }

    public async Task<List<Foodbank>> FoodbanksSearchByPostcode(string postcode)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/2/foodbanks/search/?address={postcode}");
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<List<Foodbank>>(_jsonSerializerOptions);
        return result;
    }

    public async Task<List<Foodbank>> FoodbanksSearchByCoordinates(double latitude, double longitude)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/2/foodbanks/search/?lat_lng={latitude},{longitude}");
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<List<Foodbank>>(_jsonSerializerOptions);
        return result;
    }

    public async Task<Foodbank> FoodbankBySlug(string slug)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/2/foodbank/{slug}");
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<Foodbank>(_jsonSerializerOptions);
        return result;
    }
}
