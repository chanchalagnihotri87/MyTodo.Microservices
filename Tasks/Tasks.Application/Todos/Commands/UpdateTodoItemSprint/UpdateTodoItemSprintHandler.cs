
using Tasks.Application.Data;

namespace Tasks.Application.Todos.Commands.UpdateTodoItemSprint;



public class UpdateTodoItemSprintHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTodoItemSprintCommand, UpdateTodoItemTextResult>
{
    public async Task<UpdateTodoItemTextResult> Handle(UpdateTodoItemSprintCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(command.Id, cancellationToken);

        if (todoItem == null || todoItem.UserId != command.UserId)
        {
            throw new NotFoundException("Todo Item", command.Id);
        }

        todoItem.SprintId = command.SprintId;

        dbContext.TodoItems.Update(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTodoItemTextResult(true);
    }
}
