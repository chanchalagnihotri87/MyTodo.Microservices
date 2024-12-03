
namespace Objectives.API.Objectives.DeleteObjective;

public record DeleteObjectiveResponse(bool IsSuccess);

public class DeleteObjectiveEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/objectives/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteObjectiveCommand(id, UserConstants.UserId));

            var response = result.Adapt<DeleteObjectiveResponse>();

            return Results.Ok(response);
        }).
        WithName("Delete Objective").
        WithDescription("Delete Objective").
        WithSummary("Delete Objective").
        Produces<DeleteObjectiveResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
