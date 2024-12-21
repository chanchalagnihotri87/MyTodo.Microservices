namespace Sprints.API.Sprints.DeleteSprint;

public record DeleteSprintCommand(int Id, Guid UserId) : ICommand<DeleteSprintResult>;

public record DeleteSprintResult(bool IsSuccess);

public class DeleteSprintHandler(SprintDbContext dbContext) : ICommandHandler<DeleteSprintCommand, DeleteSprintResult>
{
    public async Task<DeleteSprintResult> Handle(DeleteSprintCommand command, CancellationToken cancellationToken)
    {
        var sprint = await dbContext.Sprints.FindAsync(command.Id, cancellationToken);

        if (sprint == null || sprint.UserId != command.UserId)
        {
            throw new NotFoundException("Sprint", command.Id);
        }

        dbContext.Sprints.Remove(sprint);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteSprintResult(true);
    }
}
