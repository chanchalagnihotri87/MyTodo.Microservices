using Objectives.API.Domain;

namespace Objectives.API.Objectives.ToggleTwentyPercent;

public record ToggleTwentyPercentCommand(int Id, bool TwentyPercent, Guid UserId):ICommand<ToggleTwentyPercentResult>;

public record ToggleTwentyPercentResult(bool IsSuccess);

public class ToggleTwentyPercentHandler(IDocumentSession session) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var objective = await session.LoadAsync<Objective>(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Objective", command.Id);
        }

        objective.TwentyPercent = command.TwentyPercent;

        session.Update<Objective>(objective);

        await session.SaveChangesAsync();

        return new ToggleTwentyPercentResult(true);
    }
}
 