using DnnAspire.Foodbanks.Web.Models;
using IdentityModel;
using System.Text;
using System.Text.Json;

namespace DnnAspire.Foodbanks.Web.Services;

public class UserPreferencesService(IHttpClientFactory clientFactory,
                                    IHttpContextAccessor httpContext)
{
    public async Task<UserPreferencesModel?> GetUserPreferences()
    {
        if (!(httpContext?.HttpContext?.User?.Identity?.IsAuthenticated ?? false))
        {
            return null;
        }

        var userId = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject);

        var client = clientFactory.CreateClient("userPreferencesClient");

        var request = new HttpRequestMessage(HttpMethod.Get, $"/userpreferences/{userId.Value}");

        var response = await client.SendAsync(request);

        var userPreferences = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<UserPreferencesModel?>()
            : null;

        return userPreferences;
    }

    public async Task<UserPreferencesModel?> UpdateUserPreferences(string slug)
    {
        if (!(httpContext?.HttpContext?.User?.Identity?.IsAuthenticated ?? false))
        {
            return null;
        }

        var userId = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject);

        var client = clientFactory.CreateClient("userPreferencesClient");

        var request = new HttpRequestMessage(HttpMethod.Post, $"/userpreferences/{userId}");
        var json = JsonSerializer.Serialize(new UserPreferencesModel
        {
            UserId = userId.Value,
            PreferredFoodbankSlug = slug
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        request.Content = content;

        var response = await client.SendAsync(request);

        var userPreferences = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<UserPreferencesModel?>()
            : null;

        return userPreferences;
    }
}
