
using Goals.API.Data;
using Goals.API.Domain;

namespace Goals.API.Goals.ToggleComplete;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId):ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);

public class ToggleCompleteHandler(GoalDbContext dbContext) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var goal = await dbContext.Goals.FindAsync(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        goal.Completed = command.Completed;

        dbContext.Goals.Update(goal);

        await dbContext.SaveChangesAsync();

        return new ToggleCompletedResult(true);
    }
}
