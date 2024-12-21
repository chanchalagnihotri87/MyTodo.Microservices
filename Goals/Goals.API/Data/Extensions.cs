using Microsoft.EntityFrameworkCore;

namespace Goals.API.Data;

public static class Extensions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<GoalDbContext>();

        dbContext.Database.Migrate();

        return app;
    }
}
