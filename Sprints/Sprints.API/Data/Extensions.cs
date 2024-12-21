using Microsoft.EntityFrameworkCore;

namespace Objectives.API.Data;

public static class Extensions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<SprintDbContext>();

        dbContext.Database.Migrate();

        return app;
    }
}
