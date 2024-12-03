using Tasks.Application.Data;

namespace Tasks.Application.Todos.Commands.DeleteTodoItem;

public class DeleteTodoItemHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteTodoItemCommand, DeleteTodoItemResult>
{
    public async Task<DeleteTodoItemResult> Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(command.Id);

        if (todoItem == null || todoItem.UserId != command.UserId)
        {
            throw new NotFoundException("TodoItem", command.Id);
        }

        dbContext.TodoItems.Remove(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteTodoItemResult(true);
    }
}
