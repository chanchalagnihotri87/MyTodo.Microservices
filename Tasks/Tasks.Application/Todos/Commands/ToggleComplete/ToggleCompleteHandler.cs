using Tasks.Application.Data;

namespace Tasks.Application.Todos.Commands.ToggleComplete;

public class ToggleCompleteHandler(IApplicationDbContext dbContext) : ICommandHandler<ToggleCompletedCommand, ToggleCompletedResult>
{
    public async Task<ToggleCompletedResult> Handle(ToggleCompletedCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(command.Id, cancellationToken);

        if (todoItem == null || todoItem.UserId != command.UserId)
        {
            throw new NotFoundException("Todo Item", command.Id);
        }

        todoItem.UpdateCompletedFlag(command.Completed);

        dbContext.TodoItems.Update(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ToggleCompletedResult(true);
    }
}
