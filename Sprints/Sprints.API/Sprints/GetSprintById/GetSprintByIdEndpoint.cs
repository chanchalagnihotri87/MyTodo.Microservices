
namespace Sprints.API.Sprints.GetSprintById;

public record GetSprintByIdResponse(SprintDto Sprint);

public class GetSprintByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/sprints/detail/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new GetSprintByIdQuery(id, UserConstants.UserId));

            var response = result.Adapt<GetSprintByIdResponse>();

            return Results.Ok(response);

        }).WithName("Get Sprint By Id").
        WithDescription("Get Sprint By Id").
        WithSummary("Get Sprint By Id").
        Produces<GetSprintByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
