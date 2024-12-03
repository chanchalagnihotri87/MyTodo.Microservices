using Tasks.Application.Data;
using Tasks.Domain.Models;

namespace Tasks.Application.Todos.Commands.CreateTodoItem;

public class CreateTodoItemHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateTodoItemCommand, CreateTodoItemResult>
{
    public async Task<CreateTodoItemResult> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = command.TodoItem.Adapt<TodoItem>();

        todoItem.Id = 0;
        todoItem.UserId = command.UserId;
        todoItem.Index = dbContext.Tasks.Any(x => x.UserId == command.UserId && x.ObjectiveId == command.TodoItem.TaskId) ? dbContext.Tasks.Where(x => x.UserId == command.UserId && x.ObjectiveId == command.TodoItem.TaskId).Max(x => x.Index) + 1 : 1;

        dbContext.TodoItems.Add(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTodoItemResult(todoItem.Id);
    }
}
