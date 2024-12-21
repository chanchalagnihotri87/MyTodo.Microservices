
using Goals.API.Data;
using Goals.API.Domain;

namespace Goals.API.Goals.ToggleTwentyPercent;

public record ToggleTwentyPercentCommand(int Id, bool TwentyPercent, Guid UserId):ICommand<ToggleTwentyPercentResult>;

public record ToggleTwentyPercentResult(bool IsSuccess);

public class ToggleTwentyPercentHandler(GoalDbContext dbContext) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var goal = await dbContext.Goals.FindAsync(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        goal.TwentyPercent = command.TwentyPercent;

        dbContext.Goals.Update(goal);

        await dbContext.SaveChangesAsync();

        return new ToggleTwentyPercentResult(true);
    }
}
 