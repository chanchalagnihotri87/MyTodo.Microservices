using Goals.API.Domain;

namespace Goals.API.Goals.GetGoalById;

public record DeleteGoalCommand(int Id, Guid UserId) : ICommand<DeleteGoalResult>;

public record DeleteGoalResult(bool IsSuccess);

public class DeleteGoalHandler(IDocumentSession session) : ICommandHandler<DeleteGoalCommand, DeleteGoalResult>
{
    public async Task<DeleteGoalResult> Handle(DeleteGoalCommand command, CancellationToken cancellationToken)
    {
        var goal = await session.LoadAsync<Goal>(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        session.Delete<Goal>(goal);

        await session.SaveChangesAsync(cancellationToken);

        return new DeleteGoalResult(true);
    }

   
}
