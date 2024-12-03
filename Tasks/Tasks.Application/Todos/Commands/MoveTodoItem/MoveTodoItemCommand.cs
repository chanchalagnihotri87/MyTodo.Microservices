
namespace Tasks.Application.Todos.Commands.MoveTodoItem;


public record MoveTodoItemCommand(int Id, int TaskId, int index, Guid UserId) : ICommand<MoveTodoItemResult>;

public record MoveTodoItemResult(bool IsSuccess);