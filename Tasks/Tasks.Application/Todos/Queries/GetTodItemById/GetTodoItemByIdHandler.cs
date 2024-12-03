using Tasks.Application.Data;

namespace Tasks.Application.Todos.Queries.GetTodItemById;

public class GetTodoItemByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTodoItemByIdQuery, GetTodoItemByIdResult>
{
    public async Task<GetTodoItemByIdResult> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
    {
        var todoItem = await dbContext.TodoItems.FindAsync(request.Id);

        if (todoItem == null || todoItem.UserId != request.UserId)
        {
            throw new NotFoundException("TodoItem", request.Id);
        }

        return new GetTodoItemByIdResult(todoItem.Adapt<TodoItemDto>());
    }
}
