
using Goals.API.Domain;

namespace Goals.API.Goals.ToggleComplete;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId):ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);

public class ToggleCompleteHandler(IDocumentSession session) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var goal = await session.LoadAsync<Goal>(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        goal.Completed = command.Completed;

        session.Update<Goal>(goal);

        await session.SaveChangesAsync();

        return new ToggleCompletedResult(true);
    }
}
