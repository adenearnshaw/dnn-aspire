namespace DnnAspire.Foodbanks.Web.Models;

public record UserPreferencesModel
{
    public string UserId { get; set; }
    public string PreferredFoodbankSlug { get; set; }
}
