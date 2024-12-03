
namespace Tasks.Application.Tasks.Commands.MoveTask;


public record MoveTaskCommand(int Id, int ObjectiveId, int index, Guid UserId) : ICommand<MoveTaskResult>;

public record MoveTaskResult(bool IsSuccess);