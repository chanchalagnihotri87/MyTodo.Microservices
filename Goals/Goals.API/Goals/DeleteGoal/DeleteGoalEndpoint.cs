using Goals.API.Goals.GetGoalById;

namespace Goals.API.Goals.DeleteGoal;

public record DeleteGoalResponse(bool IsSuccess);

public class DeleteGoalEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/goals/{id}", async (int id, ISender sender) =>
        {

            var result = await sender.Send(new DeleteGoalCommand(id, UserConstants.UserId));

            var response = result.Adapt<DeleteGoalResponse>();

            return Results.Ok(response);
        }).
        WithName("Delete Goal").
        WithDescription("Delete Goal").
        WithSummary("Delete Goal").
        Produces<GetGoalByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
