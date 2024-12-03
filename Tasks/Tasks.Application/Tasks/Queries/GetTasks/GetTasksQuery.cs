namespace Tasks.Application.Tasks.Queries.GetTasks;

public record GetTasksQuery(int ObjectiveId, Guid UserId) : IQuery<GetTasksResult>;

public record GetTasksResult(IEnumerable<TaskDto> Tasks);
