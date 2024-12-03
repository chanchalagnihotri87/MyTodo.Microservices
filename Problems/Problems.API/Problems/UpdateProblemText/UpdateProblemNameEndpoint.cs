namespace Problems.API.Problems.UpdateProblemText;

public record UpdateProblemTextRequest(string Text);

public record UpdateProblemTextResponse(bool IsSuccess);

public class UpdateProblemNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/problems/text/{id}", async (int id, UpdateProblemTextRequest request, ISender sender) =>
        {
            var command = new UpdateProblemTextCommand(id, request.Text, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProblemTextResponse>();

            return Results.Ok(result);
        }).
        WithName("Update Problem Text").
        WithDescription("Update Problem Text").
        WithSummary("Update Description Text").
        Produces<UpdateProblemTextResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
