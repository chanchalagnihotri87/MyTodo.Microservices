namespace Sprints.API.Sprints.GetSprints;

public record GetSprintsResponse(IEnumerable<SprintDto> Sprints);

public class GetSprintsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/sprints", async (ISender sender) =>
        {
            var result = await sender.Send(new GetSprintsQuery(UserConstants.UserId));

            var response = result.Adapt<GetSprintsResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Sprints").
        WithDescription("Get Sprints").
        WithSummary("Get Sprints").
        Produces<GetSprintsResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
