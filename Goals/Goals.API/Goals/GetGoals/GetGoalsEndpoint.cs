
namespace Goals.API.Goals.GetGoals;

public record GetGoalsResponse(IEnumerable<GoalDto> Goals);

public class GetGoalsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/goals/{problemId}", async (int problemId, ISender sender) =>
        {
            var result = await sender.Send(new GetGoalsQuery(problemId, UserConstants.UserId));

            var response = result.Adapt<GetGoalsResponse>();

            return Results.Ok(response);
        });
    }
}
