using Microsoft.EntityFrameworkCore;

namespace DnnAspire.UserPreferences.Api;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {   
    }

    public DbSet<UserPreference> UserPreferences { get; set; }
}
