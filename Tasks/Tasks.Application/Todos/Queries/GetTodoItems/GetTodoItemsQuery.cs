namespace Tasks.Application.Todos.Queries.GetTodoItems;

public record GetTodoItemsQuery(int TaskId, Guid UserId) : IQuery<GetTodoItemsResult>;

public record GetTodoItemsResult(IEnumerable<TodoItemDto> TodoItems);
