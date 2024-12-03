
namespace Goals.API.Goals.ToggleComplete;

public record ToggleCompletedRequest(bool Completed);

public record ToggleCompletedResponse(bool IsSuccess);

public class ToggleCompleteEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/goals/complete/{id}", async (int id, ToggleCompletedRequest request, ISender sender) =>
        {
            var command = new ToggleCompletedCommand(id, request.Completed, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<ToggleCompletedResponse>();

            return Results.Ok(response);
        }).
       WithName("Toggle Goal Completed").
       WithDescription("Toggle Goal Completed").
       WithSummary("Toggle Goal Completed").
       Produces<ToggleCompletedResponse>(StatusCodes.Status200OK).
       ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
