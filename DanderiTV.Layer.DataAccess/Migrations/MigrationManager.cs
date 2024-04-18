
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DanderiTV.Layer.DataAccess.Migrations
{
    public static class MigrationManager
    {
         public static IHost MigrateDatabase(this IHost host)
    {
                using (var scope = host.Services.CreateScope())
                {
                    var databaseService = scope.ServiceProvider.GetRequiredService<DatabaseSetting>();
                    var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                        try
                        {
                             //databaseService.CreateDatabase("DanderiTV");

                               //migrationService.ListMigrations();
                               //migrationService.MigrateUp(2410230001);
                        }
                        catch
                        {
                             //log errors or ...
                              throw;
                        }
                }
                return host;
            }
    }
}
