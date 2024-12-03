
using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Commands.UpdateObjectiveText;



public class UpdateTaskTextHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTaskTextCommand, UpdateTaskTexttResult>
{
    public async Task<UpdateTaskTexttResult> Handle(UpdateTaskTextCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FindAsync(command.Id, cancellationToken);

        if (task == null || task.UserId != command.UserId)
        {
            throw new NotFoundException("Task", command.Id);
        }

        task.Text = command.Text;

        dbContext.Tasks.Update(task);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTaskTexttResult(true);
    }
}
