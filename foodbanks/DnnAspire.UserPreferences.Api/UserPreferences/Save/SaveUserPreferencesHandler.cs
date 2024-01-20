using DnnAspire.UserPreferences.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace DnnAspire.UserPreferences.Api.UserPreferences.Save;

public class SaveUserPreferencesHandler(AppDbContext dbContext)
{
    public async Task<UserPreference> Handle(UserPreference userPreference)
    {
        if (Guid.Empty.Equals(userPreference.UserId))
            throw new Exception("UserID must be set");

        var storedPreferences = await dbContext.UserPreferences.FirstOrDefaultAsync(up => up.UserId == userPreference.UserId);

        if (storedPreferences is null)
        {
            storedPreferences = userPreference;
            storedPreferences.Id = Guid.NewGuid();
            await dbContext.AddAsync(storedPreferences);
        }
        else
        {
            storedPreferences.PreferredFoodbankSlug = userPreference.PreferredFoodbankSlug;
        }

        await dbContext.SaveChangesAsync();

        return storedPreferences;
    }
}
