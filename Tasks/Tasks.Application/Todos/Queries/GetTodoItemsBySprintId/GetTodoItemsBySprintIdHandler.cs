
using Mapster;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Data;

namespace Tasks.Application.Todos.Queries.GetTodoItems;

public class GetTodoItemsBySprintIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTodoItemsBySprintIdQuery, GetTodoItemsBySprintIdResult>
{
    public async Task<GetTodoItemsBySprintIdResult> Handle(GetTodoItemsBySprintIdQuery query, CancellationToken cancellationToken)
    {
        var todoITems = await dbContext.TodoItems.Where(x => x.SprintId == query.SprintId && x.UserId == query.UserId).ToHashSetAsync();

        return new GetTodoItemsBySprintIdResult(todoITems.Adapt<IEnumerable<TodoItemDto>>());
    }
}
