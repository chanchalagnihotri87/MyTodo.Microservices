using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Queries.GetTaskById;

public class GetTaskByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTaskByIdQuery, GetTaskByIdResult>
{
    public async Task<GetTaskByIdResult> Handle(GetTaskByIdQuery query, CancellationToken cancellationToken)
    {
     var task= await  dbContext.Tasks.FindAsync(query.Id);

        if (task == null || task.UserId!=query.UserId ) {

            throw new NotFoundException("Task", query.Id);
        }

        return new GetTaskByIdResult(task.Adapt<TaskDto>());
    }
}
