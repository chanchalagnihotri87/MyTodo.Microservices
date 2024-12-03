namespace Goals.API.Goals.CreateGoal;

public record CreateGoalRequest(GoalDto Goal);

public record CreateGoalResponse(int Id);

public class CreateGoalEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/goals", async (CreateGoalRequest request, ISender sender) =>
        {
            var command = new CreateGoalCommand(request.Goal, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<CreateGoalResponse>();

            return Results.Created($"/goals/detail/{response.Id}", response);
        }).
        WithName("Create Goal").
        WithDescription("Create Goal").
        WithSummary("Create Goal").
        Produces<CreateGoalResponse>(StatusCodes.Status201Created).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
