using Objectives.API.Domain;

namespace Objectives.API.Objectives.DeleteObjective;

public record DeleteObjectiveCommand(int Id, Guid UserId) : ICommand<DeleteObjectiveResult>;

public record DeleteObjectiveResult(bool IsSuccess);

public class DeleteObjectiveHandler(IDocumentSession session) : ICommandHandler<DeleteObjectiveCommand, DeleteObjectiveResult>
{
    public async Task<DeleteObjectiveResult> Handle(DeleteObjectiveCommand command, CancellationToken cancellationToken)
    {
        var objective = await session.LoadAsync<Objective>(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Objective", command.Id);
        }

        session.Delete(objective);

        await session.SaveChangesAsync();

        return new DeleteObjectiveResult(true);
    }
}
