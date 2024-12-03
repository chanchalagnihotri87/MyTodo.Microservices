
using Tasks.Application.Tasks.Commands.MoveTask;

namespace Tasks.API.EndPoints.Tasks;


public record MoveTaskRequest(int ObjectiveId, int Index);

public record MoveTaskResponse(bool IsSuccess);

public class MoveTodoItemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/tasks/move/{id}", async (int Id, MoveTaskRequest request, ISender sender) =>
        {
            var command = new MoveTaskCommand(Id, request.ObjectiveId, request.Index, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<MoveTaskResponse>();

            return Results.Ok(response);
        }).
        WithName("Move Task").
        WithDescription("Move Task").
        WithSummary("Move TaskTask").
        Produces<MoveTaskResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
