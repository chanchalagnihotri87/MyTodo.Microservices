using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteTaskCommand, DeleteTaskResult>
{
    public async Task<DeleteTaskResult> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FindAsync(command.Id);

        if (task == null || task.UserId != command.UserId)
        {
            throw new NotFoundException("Task", command.Id);
        }

        dbContext.Tasks.Remove(task);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteTaskResult(true);
    }
}
