using Microsoft.EntityFrameworkCore;
using Tasks.Application.Data;

namespace Tasks.Application.Todos.Commands.MoveTodoItem;


public class MoveTodoItemHandler(IApplicationDbContext dbContext) : ICommandHandler<MoveTodoItemCommand, MoveTodoItemResult>
{
    public async Task<MoveTodoItemResult> Handle(MoveTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItems = await dbContext.TodoItems.Where(x => x.UserId == command.UserId && x.TaskId == command.TaskId).ToListAsync(); ;

        var draggedTodoItem = todoItems.First(x => x.Id == command.Id);

        if (draggedTodoItem == null)
        {
            throw new NotFoundException("Todo Item", command.UserId);
        }

        int newIndex = command.index;

        if (newIndex == draggedTodoItem!.Index)
        {
            return new MoveTodoItemResult(true);
        }

        if (newIndex < draggedTodoItem!.Index)
        {
            foreach (var todoItem in todoItems.Where(t => t.Index >= newIndex && t.Index <= draggedTodoItem.Index))
            {
                todoItem.Index++;
            }
        }
        else
        {
            foreach (var todoItem in todoItems.Where(t => t.Index >= draggedTodoItem.Index && t.Index <= newIndex))
            {
                todoItem.Index--;
            }
        }

        draggedTodoItem.Index = newIndex;

        dbContext.TodoItems.UpdateRange(todoItems);

        await dbContext.SaveChangesAsync(cancellationToken);


        return new MoveTodoItemResult(true);

    }
}
