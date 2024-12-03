
using Mapster;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Data;

namespace Tasks.Application.Todos.Queries.GetTodoItems;

public class GetTodoItemsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTodoItemsQuery, GetTodoItemsResult>
{
    public async Task<GetTodoItemsResult> Handle(GetTodoItemsQuery query, CancellationToken cancellationToken)
    {
        var todoITems = await dbContext.TodoItems.Where(x => x.TaskId == query.TaskId && x.UserId == query.UserId).ToHashSetAsync();

        return new GetTodoItemsResult(todoITems.Adapt<IEnumerable<TodoItemDto>>());
    }
}
