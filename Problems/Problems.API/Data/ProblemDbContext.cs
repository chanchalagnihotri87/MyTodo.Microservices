using Microsoft.EntityFrameworkCore;
using Problems.API.Domain;

namespace Problems.API.Data
{
    public class ProblemDbContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }

        public ProblemDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Problem>().HasData(
               new Problem
               {
                   Id = 1,
                   Text = "Not able to speak in english",
                   LifeAreaId = 1,
                   Completed = true,
                   TwentyPercent = true,
                   Index = 1,
                   User_Id = UserConstants.UserId
               },
                new Problem
                {
                    Id = 2,
                    Text = "Lack of sales man skill",
                    LifeAreaId = 1,
                    Completed = true,
                    TwentyPercent = true,
                    Index = 2,
                    User_Id = UserConstants.UserId
                },
                new Problem
                {
                    Id = 3,
                    Text = "Build product from scratch",
                    LifeAreaId = 1,
                    Completed = true,
                    TwentyPercent = true,
                    Index = 3,
                    User_Id = UserConstants.UserId
                },
                new Problem
                {
                    Id = 4,
                    Text = "Business mindset",
                    LifeAreaId = 1,
                    Completed = true,
                    TwentyPercent = true,
                    Index = 1,
                    User_Id = UserConstants.UserId
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
