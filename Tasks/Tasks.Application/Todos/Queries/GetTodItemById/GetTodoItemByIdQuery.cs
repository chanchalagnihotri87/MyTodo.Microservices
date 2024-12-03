namespace Tasks.Application.Todos.Queries.GetTodItemById;

public record GetTodoItemByIdQuery(int Id, Guid UserId) : IQuery<GetTodoItemByIdResult>;

public record GetTodoItemByIdResult(TodoItemDto TodoItem);
