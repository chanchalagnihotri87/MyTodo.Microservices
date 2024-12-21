using Objectives.API.Data;
using Objectives.API.Domain;

namespace Objectives.API.Objectives.DeleteObjective;

public record DeleteObjectiveCommand(int Id, Guid UserId) : ICommand<DeleteObjectiveResult>;

public record DeleteObjectiveResult(bool IsSuccess);

public class DeleteObjectiveHandler(ObjectiveDbContext dbContext) : ICommandHandler<DeleteObjectiveCommand, DeleteObjectiveResult>
{
    public async Task<DeleteObjectiveResult> Handle(DeleteObjectiveCommand command, CancellationToken cancellationToken)
    {
        var objective = await dbContext.Objectives.FindAsync(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Objective", command.Id);
        }

        dbContext.Objectives.Remove(objective);

        await dbContext.SaveChangesAsync();

        return new DeleteObjectiveResult(true);
    }
}
