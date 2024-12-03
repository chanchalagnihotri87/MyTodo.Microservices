
namespace Objectives.API.Objectives.UpdateObjectiveText;

public record UpdateObjectivelTextRequest(string Text);

public record UpdateObjectiveTextResponse(bool IsSuccess);

public class UpdateObjectiveTextEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/objectives/text/{id}", async (int id, UpdateObjectivelTextRequest request, ISender sender) =>
        {
            var command = new UpdateObjectiveTextCommand(id, request.Text, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateObjectiveTextResponse>();

            return Results.Ok(response);
        }).
        WithName("Update Objective Text").
        WithDescription("Update Objective Text").
        WithSummary("Update Objective Text").
        Produces<UpdateObjectiveTextResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
