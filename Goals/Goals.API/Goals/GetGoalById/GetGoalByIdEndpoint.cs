using Goals.API.Goals.DeleteGoal;

namespace Goals.API.Goals.GetGoalById;

public record GetGoalByIdResponse(GoalDto Goal);
public class GetGoalByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/goals/detail/{id}", async (int id, ISender sender) =>
        {

            var result = await sender.Send(new GetGoalByIdQuery(id, UserConstants.UserId));

            var response = result.Adapt<GetGoalByIdResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Goal By Id").
        WithDescription("Get Goal By Id").
        WithSummary("Get Goal By Id").
        Produces<GetGoalByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
