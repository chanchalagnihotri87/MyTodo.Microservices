using Objectives.API.Data;
using Objectives.API.Domain;

namespace Objectives.API.Objectives.ToggleTwentyPercent;

public record ToggleTwentyPercentCommand(int Id, bool TwentyPercent, Guid UserId):ICommand<ToggleTwentyPercentResult>;

public record ToggleTwentyPercentResult(bool IsSuccess);

public class ToggleTwentyPercentHandler(ObjectiveDbContext dbContext) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var objective = await dbContext.Objectives.FindAsync(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Objective", command.Id);
        }

        objective.TwentyPercent = command.TwentyPercent;

        dbContext.Objectives.Update(objective);

        await dbContext.SaveChangesAsync();

        return new ToggleTwentyPercentResult(true);
    }
}
 