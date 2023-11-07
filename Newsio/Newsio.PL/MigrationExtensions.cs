﻿using Microsoft.EntityFrameworkCore;
using Newsio.DAL.EF;

namespace Newsio.PL
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<NewsContext>();

            if (dbContext is not null && app.Environment.IsProduction())
            {
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    app.Logger.LogError($"Could not apply migrations. {ex.Message}");
                    throw;
                }
            }
        }
    }
}
