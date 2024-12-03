namespace Problems.API.Problems.CreateProblem;

public record CreateProblemRequest(ProblemDto Problem);
public record CreateProblemResponse(int Id);

public class CreateProblemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/problems", async (CreateProblemRequest request, ISender sender) =>
        {
            var command = new CreateProblemCommand(request.Problem, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProblemResponse>();

            return Results.Created($"/problems/detail/{response.Id}", response);
        }).
        WithName("Create Problem").
        WithSummary("Create Problem").
        WithDescription("Create Problem").
        Produces<CreateProblemResponse>(StatusCodes.Status201Created).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
