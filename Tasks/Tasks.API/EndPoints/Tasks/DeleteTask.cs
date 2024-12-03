using Tasks.Application.Tasks.Commands.DeleteTask;

namespace Tasks.API.EndPoints.Tasks;

public record DeleteTaskResponse(bool IsSuccess);

public class DeleteTask : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/tasks/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteTaskCommand(id, UserConstants.UserId));

            var response = result.Adapt<DeleteTaskResponse>();

            return Results.Ok(response);
        }).
        WithName("Delete Task").
        WithDescription("Delete Task").
        WithSummary("Delete Task").
        Produces<DeleteTaskResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
