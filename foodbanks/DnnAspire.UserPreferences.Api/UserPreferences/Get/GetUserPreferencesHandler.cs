using DnnAspire.UserPreferences.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace DnnAspire.UserPreferences.Api.UserPreferences.Get;

public class GetUserPreferencesHandler(AppDbContext dbContext)
{
    public async Task<UserPreference> Handle(Guid userId)
    {
        var storedPreferences = await dbContext.UserPreferences.FirstOrDefaultAsync(up => up.UserId == userId);
        return storedPreferences ?? new UserPreference { Id = Guid.NewGuid(), UserId = userId };
    }
}
