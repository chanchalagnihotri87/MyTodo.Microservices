namespace Tasks.Application.Tasks.Queries.GetTaskById;

public record GetTaskByIdQuery(int Id, Guid UserId):IQuery<GetTaskByIdResult>;

public record GetTaskByIdResult(TaskDto Task);

