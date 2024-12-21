using Goals.API.Data;
using Goals.API.Domain;

namespace Goals.API.Goals.GetGoalById;

public record DeleteGoalCommand(int Id, Guid UserId) : ICommand<DeleteGoalResult>;

public record DeleteGoalResult(bool IsSuccess);

public class DeleteGoalHandler(GoalDbContext dbContext) : ICommandHandler<DeleteGoalCommand, DeleteGoalResult>
{
    public async Task<DeleteGoalResult> Handle(DeleteGoalCommand command, CancellationToken cancellationToken)
    {
        var goal = await dbContext.Goals.FindAsync(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        dbContext.Goals.Remove(goal);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteGoalResult(true);
    }


}
