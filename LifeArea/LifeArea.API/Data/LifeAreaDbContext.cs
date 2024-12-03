using Microsoft.EntityFrameworkCore;

namespace LifeArea.API.Data;

public class LifeAreaDbContext : DbContext
{
    public DbSet<LifeAreaType> LifeAreas { get; set; }

    public LifeAreaDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LifeAreaType>().HasData(
           new LifeAreaType { Id = 1, Name = "Business" },
           new LifeAreaType { Id = 2, Name = "Health" },
           new LifeAreaType { Id = 3, Name = "Family" },
           new LifeAreaType { Id = 4, Name = "Finance" },
           new LifeAreaType { Id = 5, Name = "Social" },
           new LifeAreaType { Id = 6, Name = "Creativity" }
           );

        base.OnModelCreating(modelBuilder);
    }
}
