using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tasks.Application.Data;
using Tasks.Domain.Models;

namespace Tasks.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Domain.Models.Task> Tasks => Set<Domain.Models.Task>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
