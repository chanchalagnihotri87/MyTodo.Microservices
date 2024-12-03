using Microsoft.EntityFrameworkCore;

namespace LifeArea.API.Data;

public static class Extensions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<LifeAreaDbContext>();

        dbContext.Database.Migrate();

        return app;
    }
}
