using Sprints.API.Domain;

namespace Sprints.API.Sprints.DeleteSprint;

public record DeleteSprintCommand(int Id, Guid UserId) : ICommand<DeleteSprintResult>;

public record DeleteSprintResult(bool IsSuccess);

public class DeleteSprintHandler(IDocumentSession session) : ICommandHandler<DeleteSprintCommand, DeleteSprintResult>
{
    public async Task<DeleteSprintResult> Handle(DeleteSprintCommand command, CancellationToken cancellationToken)
    {
        var sprint = await session.LoadAsync<Sprint>(command.Id, cancellationToken);

        if (sprint == null || sprint.UserId != command.UserId)
        {
            throw new NotFoundException("Sprint", command.Id);
        }

        session.Delete(sprint);

        await session.SaveChangesAsync(cancellationToken);

        return new DeleteSprintResult(true);
    }
}
