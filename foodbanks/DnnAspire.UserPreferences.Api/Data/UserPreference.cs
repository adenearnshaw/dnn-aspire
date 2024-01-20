namespace DnnAspire.UserPreferences.Api.Data;

public class UserPreference
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string PreferredFoodbankSlug { get; set; }
}
