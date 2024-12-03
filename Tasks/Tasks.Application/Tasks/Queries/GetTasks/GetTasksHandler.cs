
using Mapster;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Queries.GetTasks;

public class GetTasksHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTasksQuery, GetTasksResult>
{
    public async Task<GetTasksResult> Handle(GetTasksQuery query, CancellationToken cancellationToken)
    {
        var tasks = await dbContext.Tasks.Where(x => x.ObjectiveId == query.ObjectiveId && x.UserId == query.UserId).ToListAsync(cancellationToken);

        return new GetTasksResult(tasks.Adapt<List<TaskDto>>());
    }
}
