
using Goals.API.Domain;

namespace Goals.API.Goals.ToggleTwentyPercent;

public record ToggleTwentyPercentCommand(int Id, bool TwentyPercent, Guid UserId):ICommand<ToggleTwentyPercentResult>;

public record ToggleTwentyPercentResult(bool IsSuccess);

public class ToggleTwentyPercentHandler(IDocumentSession session) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var goal = await session.LoadAsync<Goal>(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        goal.TwentyPercent = command.TwentyPercent;

        session.Update<Goal>(goal);

        await session.SaveChangesAsync();

        return new ToggleTwentyPercentResult(true);
    }
}
 