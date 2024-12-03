namespace Problems.API.Problems.GetProblems;

//public record GetProblemsRequest(int LifeAreaId)

public record GetProblemResponse(IEnumerable<ProblemDto> Problems);

public class GetProblemsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/problems/{lifeAreaId}", async (int lifeAreaId, ISender sender) =>
        {

            var result = await sender.Send(new GetProblemsQuery(lifeAreaId, UserConstants.UserId));

            var response = result.Adapt<GetProblemResponse>();

            return Results.Ok(response);
        }).WithName("Get Problems").
        WithDescription("Get Problems").
        WithSummary("Get Problems").
        Produces<GetProblemResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
