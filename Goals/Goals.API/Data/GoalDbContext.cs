using Goals.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Goals.API.Data
{
    public class GoalDbContext : DbContext
    {
        public DbSet<Goal> Goals { get; set; }

        public GoalDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>().HasData(new List<Goal>
            {new Goal
            {
                Id=1,
                Text="Correct in english",
                ProblemId=1,
                TwentyPercent=true,
                Completed=true,
                UserId=UserConstants.UserId
            },
            new Goal
            {
                Id= 2,
                Text="Confidence in english",
                ProblemId=1,
                TwentyPercent=true,
                Completed=true,
                UserId=UserConstants.UserId
            },
              new Goal
            {
                Id= 3,
                Text="Speaking fast",
                ProblemId=1,
                TwentyPercent=true,
                Completed=true,
                UserId=UserConstants.UserId
            },
            new Goal
            {
                Id= 4,
                Text="Fluent in english",
                ProblemId=1,
                TwentyPercent=false,
                Completed=false,
                UserId=UserConstants.UserId
            }

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
