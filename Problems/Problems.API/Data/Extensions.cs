using Microsoft.EntityFrameworkCore;

namespace Problems.API.Data;

public static class Extensions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<ProblemDbContext>();

        dbContext.Database.Migrate();

        return app;
    }
}
