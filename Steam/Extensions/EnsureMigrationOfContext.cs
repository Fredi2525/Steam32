
using Microsoft.EntityFrameworkCore;

namespace Steam.WebApp.Extensions;

public static class EnsureMigrationExtension
{
    public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : DbContext
    {
        var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<T>();
        if (!context.Database.IsInMemory())
        {
            context.Database.Migrate();
        }
    }
}