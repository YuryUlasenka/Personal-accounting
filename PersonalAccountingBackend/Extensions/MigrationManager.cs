using System;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace PersonalAccountingBackend.Extensions
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp, ILoggerManager logger)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
                {
                    try
                    {
                        var allMigrations = appContext.Database.GetMigrations();
                        var pendingMigrations = appContext.Database.GetPendingMigrations();
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError($"Error during migration: {ex.Message}");
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
