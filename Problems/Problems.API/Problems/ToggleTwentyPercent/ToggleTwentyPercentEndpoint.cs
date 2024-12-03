
using Problems.API.Problems.ToggleCompleted;

namespace Problems.API.Problems.ToggleTwentyPercent;

public record ToggleTwentyPercentRequest(bool TwentyPercent);

public record ToggleTwentyPercentResponse(bool IsSuccess);

public class ToggleTwentyPercentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/problems/twentypercent/{id}", async (int id, ToggleTwentyPercentRequest request, ISender sender) =>
        {
            var command = new ToggleTwentyPercentCommand(id, request.TwentyPercent, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<ToggleTwentyPercentResponse>();

            return Results.Ok(response);
        }).
        WithName("Toggle Problem 20%").
        WithDescription("Toggle Problem 20%").
        WithSummary("Toggle Problem 20%").
        Produces<ToggleTwentyPercentResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}

