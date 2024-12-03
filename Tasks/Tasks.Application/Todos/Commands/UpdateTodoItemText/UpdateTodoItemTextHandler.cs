
using Tasks.Application.Data;

namespace Tasks.Application.Todos.Commands.UpdateTodoItemText;



public class UpdateTodoItemSprintHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTodoItemTextCommand, UpdateTodoItemTextResult>
{
    public async Task<UpdateTodoItemTextResult> Handle(UpdateTodoItemTextCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(command.Id, cancellationToken);

        if (todoItem == null || todoItem.UserId != command.UserId)
        {
            throw new NotFoundException("Todo Item", command.Id);
        }

        todoItem.Text = command.Text;

        dbContext.TodoItems.Update(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTodoItemTextResult(true);
    }
}
