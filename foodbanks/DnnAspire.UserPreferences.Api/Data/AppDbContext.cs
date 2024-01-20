using Microsoft.EntityFrameworkCore;

namespace DnnAspire.UserPreferences.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserPreference> UserPreferences { get; set; }
}
