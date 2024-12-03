namespace Objectives.API.Objectives.MoveGoal;


public record MoveObjectiveRequest(int ProblemId, int Index);

public record MoveObjectiveResponse(bool IsSuccess);

public class MoveObjectiveEndpoint : ICarterModule
{
public void AddRoutes(IEndpointRouteBuilder app)
{
    app.MapPatch("/objectives/move/{id}", async (int Id, MoveObjectiveRequest request, ISender sender) =>
    {
        var command = new MoveObjectiveCommand(Id, request.ProblemId, request.Index, UserConstants.UserId);

        var result = await sender.Send(command);

        var response = result.Adapt<MoveObjectiveResponse>();

        return Results.Ok(response);
    }).
    WithName("Move Objective").
    WithDescription("Move Objective").
    WithSummary("Move Objective").
    Produces<MoveObjectiveResponse>(StatusCodes.Status200OK).
    ProducesProblem(StatusCodes.Status500InternalServerError);
}
}
