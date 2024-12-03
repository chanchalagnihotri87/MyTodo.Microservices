namespace Tasks.Application.Todos.Queries.GetTodoItems;

public record GetTodoItemsBySprintIdQuery(int SprintId, Guid UserId) : IQuery<GetTodoItemsBySprintIdResult>;

public record GetTodoItemsBySprintIdResult(IEnumerable<TodoItemDto> TodoItems);
