

namespace Sprints.API.Sprinits.ToggleComplete;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId):ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);

public class ToggleCompleteHandler(SprintDbContext dbContext) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var sprint = await dbContext.Sprints.FindAsync(command.Id, cancellationToken);

        if (sprint == null || sprint.UserId != command.UserId)
        {
            throw new NotFoundException("Sprint", command.Id);
        }

        sprint.Completed = command.Completed;

        dbContext.Sprints.Update(sprint);

        await dbContext.SaveChangesAsync();

        return new ToggleCompletedResult(true);
    }
}
