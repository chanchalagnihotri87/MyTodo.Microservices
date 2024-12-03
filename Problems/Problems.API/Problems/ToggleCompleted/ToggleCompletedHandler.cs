
using BuildingBlocks.Exceptions;
using Problems.API.Domain;

namespace Problems.API.Problems.ToggleCompleted;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId) : ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);

public class ToggleCompletedHandler(IDocumentSession session) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var problem = await session.LoadAsync<Problem>(command.Id, cancellationToken);

        if (problem == null || problem.User_Id != command.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        problem.Completed = command.Completed;

        session.Update<Problem>(problem);

        await session.SaveChangesAsync(cancellationToken);

        return new ToggleCompletedResult(true);
    }
}
