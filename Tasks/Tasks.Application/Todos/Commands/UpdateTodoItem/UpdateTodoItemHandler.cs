
using BuildingBlocks.Exceptions;
using Tasks.Application.Data;

namespace Tasks.Application.Todos.Commands.UpdateTodoItem;

public class UpdateTodoItemHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTodoItemCommand, UpdateTodoItemResult>
{
    public async Task<UpdateTodoItemResult> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(command.TodoItem.Id);

        if (todoItem == null || todoItem.UserId != command.UserId)
        {
            throw new NotFoundException("TodoItem", command.TodoItem.Id);
        }

        todoItem.Text = command.TodoItem.Text;
        todoItem.SprintId = command.TodoItem.SprintId;
        todoItem.Date = command.TodoItem.Date;
        todoItem.TwentyPercent = command.TodoItem.TwentyPercent;
        todoItem.Completed = command.TodoItem.Completed;
        todoItem.Index = command.TodoItem.Index;

        dbContext.TodoItems.Update(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTodoItemResult(true);
    }
}
