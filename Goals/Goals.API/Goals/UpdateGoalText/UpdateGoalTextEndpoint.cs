
namespace Goals.API.Goals.UpdateGoalText;

public record UpdateGoalTextRequest(string Text);

public record UpdateGoalTextResponse(bool IsSuccess);

public class UpdateGoalTextEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/goals/text/{id}", async (int id, UpdateGoalTextRequest request, ISender sender) =>
        {
            var command = new UpdateGoalTextCommand(id, request.Text, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateGoalTextResponse>();

            return Results.Ok(response);
        }).
        WithName("Update Goal Text").
        WithDescription("Update Goal Text").
        WithSummary("Update Goal Text").
        Produces<UpdateGoalTextResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
