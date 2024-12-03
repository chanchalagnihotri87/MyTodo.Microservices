
using Problems.API.Problems.DeleteProblem;

namespace Problems.API.Problems.MoveProblem;

public record MoveProblemRequest(int LifeAreaId, int Index);

public record MoveProblemResponse(bool IsSuccess);

public class MoveProblemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/problems/move/{id}", async (int Id, MoveProblemRequest request, ISender sender) =>
        {
            var command = new MoveProblemCommand(Id, request.LifeAreaId, request.Index, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<MoveProblemResponse>();

            return Results.Ok(response);
        }).
        WithName("Move Problem").
        WithDescription("Move Problem").
        WithSummary("Move Problem").
        Produces<MoveProblemResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
