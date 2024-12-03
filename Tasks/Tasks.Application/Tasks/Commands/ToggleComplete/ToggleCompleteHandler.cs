using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Commands.ToggleComplete;

public class ToggleCompleteHandler(IApplicationDbContext dbContext) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FindAsync(command.Id, cancellationToken);

        if (task == null || task.UserId != command.UserId)
        {
            throw new NotFoundException("Task", command.Id);
        }

        task.Completed = command.Completed;

        dbContext.Tasks.Update(task);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ToggleCompletedResult(true);
    }
}
