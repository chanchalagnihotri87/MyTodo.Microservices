namespace Goals.API.Goals.MoveGoal;


public record MoveGoalRequest(int ProblemId, int Index);

public record MoveGoalResponse(bool IsSuccess);

public class MoveGoalEndpoint : ICarterModule
{
public void AddRoutes(IEndpointRouteBuilder app)
{
    app.MapPatch("/goals/move/{id}", async (int Id, MoveGoalRequest request, ISender sender) =>
    {
        var command = new MoveGoalCommand(Id, request.ProblemId, request.Index, UserConstants.UserId);

        var result = await sender.Send(command);

        var response = result.Adapt<MoveGoalResponse>();

        return Results.Ok(response);
    }).
    WithName("Move Goal").
    WithDescription("Move Goal").
    WithSummary("Move Goal").
    Produces<MoveGoalResponse>(StatusCodes.Status200OK).
    ProducesProblem(StatusCodes.Status500InternalServerError);
}
}
