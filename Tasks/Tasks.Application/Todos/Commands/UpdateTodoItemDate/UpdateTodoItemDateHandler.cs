using Tasks.Application.Data;
using Tasks.Application.Todos.Commands.UpdateTodoItemSprint;

namespace Tasks.Application.Todos.Commands.UpdateTodoItemDate;


public class UpdateTodoItemDateHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTodoItemDateCommand, UpdateTodoItemDateResult>
{
    public async Task<UpdateTodoItemDateResult> Handle(UpdateTodoItemDateCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(command.Id, cancellationToken);

        if (todoItem == null || todoItem.UserId != command.UserId)
        {
            throw new NotFoundException("Todo Item", command.Id);
        }

        if (command.Date.HasValue)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            // convert the value to get it's UTC equivalent
            var timeStamp = TimeZoneInfo.ConvertTimeFromUtc(command.Date.Value, timeZone);

            todoItem.Date = timeStamp;
        }
        else
        {
            todoItem.Date = command.Date;
        }

        dbContext.TodoItems.Update(todoItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTodoItemDateResult(true);
    }
}
