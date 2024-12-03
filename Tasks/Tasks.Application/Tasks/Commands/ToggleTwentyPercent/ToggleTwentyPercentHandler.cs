using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Commands.ToggleTwentyPercent;


public class ToggleTwentyPercentHandler(IApplicationDbContext dbContext) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FindAsync(command.Id, cancellationToken);

        if (task == null || task.UserId != command.UserId)
        {
            throw new NotFoundException("Task", command.Id);
        }

        task.TwentyPercent = command.TwentyPercent;

        dbContext.Tasks.Update(task);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ToggleTwentyPercentResult(true);
    }
}
