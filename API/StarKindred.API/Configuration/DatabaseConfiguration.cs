using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using StarKindred.API.Database;

namespace StarKindred.API.Configuration;

public static class DatabaseConfiguration
{
    public static void AddAndConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Db");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            // TODO: maybe use in-memory db if nothing is configured and it's not production?
            throw new InvalidOperationException("Missing required database connection string.");
        }

        builder.Services.AddDbContext<Db>((sp, o) =>
        {
            o.UseSqlServer(connectionString, b =>
            {
                b.EnableRetryOnFailure(3);
            });

            if (builder.Environment.IsDevelopment())
            {
                o.EnableSensitiveDataLogging().EnableDetailedErrors();
            }

            if (builder.Configuration.GetValue<bool>("LogSqlToConsole"))
            {
                o.LogTo(Console.WriteLine, LogLevel.Information);
            }

            o.AddInterceptors(sp.GetRequiredService<SecondLevelCacheInterceptor>());
        });


        // TODO: when we have in-memory tables in the DB, probably get rid of EFSecondLevelCache??
        builder.Services.AddEFSecondLevelCache(options => options.UseMemoryCacheProvider());
    }
}
