using DnnAspire.UserPreferences.Api.Data;

namespace DnnAspire.UserPreferences.Api.UserPreferences.Clear;

public class ClearUserPreferencesHandler(AppDbContext dbContext)
{
    public async Task Handle()
    {
        foreach (var userPreference in dbContext.UserPreferences)
        {
            dbContext.UserPreferences.Remove(userPreference);
        }

        await dbContext.SaveChangesAsync();
    }
}