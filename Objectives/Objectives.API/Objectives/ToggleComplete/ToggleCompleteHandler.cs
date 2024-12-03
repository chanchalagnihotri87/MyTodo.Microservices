using Objectives.API.Domain;

namespace Objectives.API.Objectives.ToggleComplete;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId):ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);

public class ToggleCompleteHandler(IDocumentSession session) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var objective = await session.LoadAsync<Objective>(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        objective.Completed = command.Completed;

        session.Update<Objective>(objective);

        await session.SaveChangesAsync();

        return new ToggleCompletedResult(true);
    }
}
