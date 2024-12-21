using Microsoft.EntityFrameworkCore;
using Sprints.API.Domain;

namespace Objectives.API.Data
{
    public class SprintDbContext : DbContext
    {
        public DbSet<Sprint> Sprints { get; set; }

        public SprintDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
