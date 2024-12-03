using Tasks.Application.Data;

namespace Tasks.Application.Todos.Commands.ToggleTwentyPercent;


public class ToggleTwentyPercentHandler(IApplicationDbContext dbContext) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(command.Id, cancellationToken);

        if (todoItem == null || todoItem.UserId != command.UserId)
        {
            throw new NotFoundException("Todo Item", command.Id);
        }

        todoItem.TwentyPercent = command.TwentyPercent;

        dbContext.TodoItems.Update(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ToggleTwentyPercentResult(true);
    }
}
