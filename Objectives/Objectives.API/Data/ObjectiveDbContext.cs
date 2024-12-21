using Microsoft.EntityFrameworkCore;
using Objectives.API.Domain;

namespace Objectives.API.Data
{
    public class ObjectiveDbContext : DbContext
    {
        public DbSet<Objective> Objectives { get; set; }

        public ObjectiveDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Objective>().HasData(new List<Objective>
            {
                new Objective
            {
                Id=1,
                Text="Think about correctness",
                GoalId=1,
                TwentyPercent=true,
                Completed=true,
                UserId=UserConstants.UserId
            },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
