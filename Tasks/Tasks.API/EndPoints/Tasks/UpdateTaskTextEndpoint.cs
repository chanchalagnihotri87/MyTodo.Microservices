using Tasks.Application.Tasks.Commands.UpdateObjectiveText;

namespace Tasks.API.EndPoints.Tasks;

public record UpdateTaskTextRequest(string Text);

public record UpdateTaskTextResponse(bool IsSuccess);

public class UpdateTaskTextEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/tasks/text/{id}", async (int id, UpdateTaskTextRequest request, ISender sender) =>
        {
            var command = new UpdateTaskTextCommand(id, request.Text, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateTaskTextResponse>();

            return Results.Ok(response);
        }).
        WithName("Update Task Text").
        WithDescription("Update Task Text").
        WithSummary("Update Task Text").
        Produces<UpdateTaskTextResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
