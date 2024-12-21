using Objectives.API.Data;
using Objectives.API.Domain;

namespace Objectives.API.Objectives.ToggleComplete;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId):ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);

public class ToggleCompleteHandler(ObjectiveDbContext dbContext) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var objective = await dbContext.Objectives.FindAsync(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        objective.Completed = command.Completed;

        dbContext.Objectives.Update(objective);

        await dbContext.SaveChangesAsync();

        return new ToggleCompletedResult(true);
    }
}
