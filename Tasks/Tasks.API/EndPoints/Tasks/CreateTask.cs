using Mapster;
using Tasks.Application.Tasks.Commands.CreateTask;

namespace Tasks.API.EndPoints.Tasks;

public record CreateTaskRequest(TaskDto Task);

public record CreateTaskResponse(int Id);

public class CreateTask : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/tasks", async (CreateTaskRequest request, ISender sender) =>
        {
            var command = new CreateTaskCommand(request.Task, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<CreateTaskResponse>();

            return Results.Created($"/tasks/detail/{response.Id}", response);
        }).
        WithName("Add Task").
        WithDescription("Add Task").
        WithSummary("Add Task").
        Produces<CreateTaskResponse>(StatusCodes.Status201Created).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
