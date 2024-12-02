using GaragesStructure.DATA;
using Microsoft.EntityFrameworkCore;

namespace GaragesStructure.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<DataContext>();
        context.Database.Migrate();
    }
}