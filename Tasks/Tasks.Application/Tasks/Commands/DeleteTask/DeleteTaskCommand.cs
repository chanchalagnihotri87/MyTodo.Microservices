namespace Tasks.Application.Tasks.Commands.DeleteTask;

public record DeleteTaskCommand(int Id, Guid UserId) : ICommand<DeleteTaskResult>;

public record DeleteTaskResult(bool IsSuccess);


