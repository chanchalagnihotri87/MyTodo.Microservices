namespace Tasks.Application.Todos.Commands.ToggleComplete;

public record ToggleCompletedCommand(int Id, bool Completed, Guid UserId) : ICommand<ToggleCompletedResult>;

public record ToggleCompletedResult(bool IsSuccess);