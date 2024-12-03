using BuildingBlocks.Exceptions;
using Problems.API.Domain;
namespace Problems.API.Problems.ToggleTwentyPercent;

public record ToggleTwentyPercentCommand(int Id, bool TwentyPercent, Guid UserId) : ICommand<ToggleTwentyPercentResult>;

public record ToggleTwentyPercentResult(bool IsSuccess);

public class ToggleTwentyPercentHandler(IDocumentSession session) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var problem = await session.LoadAsync<Problem>(command.Id, cancellationToken);

        if (problem == null || problem.User_Id != command.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        problem.TwentyPercent = command.TwentyPercent;

        session.Update<Problem>(problem);

        await session.SaveChangesAsync(cancellationToken);

        return new ToggleTwentyPercentResult(true);
    }
}
