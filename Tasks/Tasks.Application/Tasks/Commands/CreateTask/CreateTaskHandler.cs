
using Mapster;
using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Commands.CreateTask;

public record CreateTaskHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateTaskCommand, CreateTaskResult>
{
    public async Task<CreateTaskResult> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var task = command.Task.Adapt<Domain.Models.Task>();

        task.Id = 0;
        task.UserId = command.UserId;
        task.Index = dbContext.Tasks.Any(x => x.UserId == command.UserId && x.ObjectiveId == command.Task.ObjectiveId) ? dbContext.Tasks.Where(x => x.UserId == command.UserId && x.ObjectiveId == command.Task.ObjectiveId).Max(x => x.Index) + 1 : 1;

        dbContext.Tasks.Add(task);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTaskResult(task.Id);
    }
}
