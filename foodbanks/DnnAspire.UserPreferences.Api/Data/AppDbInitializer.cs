using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DnnAspire.UserPreferences.Api.Data;

public class AppDbInitializer(IServiceProvider serviceProvider, ILogger<AppDbInitializer> logger)
    : BackgroundService
{
    public const string ActivitySourceName = "Migrations";

    private readonly ActivitySource _activitySource = new(ActivitySourceName);

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await InitializeDatabaseAsync(dbContext, cancellationToken);
    }

    private async Task InitializeDatabaseAsync(AppDbContext dbContext, CancellationToken cancellationToken)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();

        using var activity = _activitySource.StartActivity("Migrating catalog database", ActivityKind.Client);

        var sw = Stopwatch.StartNew();

        await strategy.ExecuteAsync(() => dbContext.Database.MigrateAsync(cancellationToken));

        logger.LogInformation("Database Migration Completed");
    }
}
