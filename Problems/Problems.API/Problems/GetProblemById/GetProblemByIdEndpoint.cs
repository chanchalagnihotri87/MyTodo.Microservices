namespace Problems.API.Problems.GetProblemById;

public record GetProblemByIdResponse(ProblemDto Problem);

public class GetProblemByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/problems/detail/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new GetProblemByIdQuery(id));

            var response = result.Adapt<GetProblemByIdResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Problem By Id").
        WithSummary("Get Problem By Id").
        WithDescription("Get Problem By Id").
        Produces<GetProblemByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
