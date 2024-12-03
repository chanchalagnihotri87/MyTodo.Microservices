
using Sprints.API.Domain;

namespace Sprints.API.Sprinits.ToggleComplete;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId):ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);

public class ToggleCompleteHandler(IDocumentSession session) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var sprint = await session.LoadAsync<Sprint>(command.Id, cancellationToken);

        if (sprint == null || sprint.UserId != command.UserId)
        {
            throw new NotFoundException("Sprint", command.Id);
        }

        sprint.Completed = command.Completed;

        session.Update<Sprint>(sprint);

        await session.SaveChangesAsync();

        return new ToggleCompletedResult(true);
    }
}
