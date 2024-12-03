
namespace Sprints.API.Sprints.DeleteSprint;

public record DeleteSprintResponse(bool IsSuccess);

public class DeleteSprintEndpont : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/sprints/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteSprintCommand(id, UserConstants.UserId));

            var response = result.Adapt<DeleteSprintResponse>();

            return Results.Ok(response);
        }).
        WithName("Delete Sprint").
        WithDescription("Delete Sprint").
        WithSummary("Delete Sprint").
        Produces<DeleteSprintResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
