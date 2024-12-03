using Microsoft.EntityFrameworkCore;
using Tasks.Domain.Models;

namespace Tasks.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.Task> Tasks { get;}

    DbSet<TodoItem> TodoItems { get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
