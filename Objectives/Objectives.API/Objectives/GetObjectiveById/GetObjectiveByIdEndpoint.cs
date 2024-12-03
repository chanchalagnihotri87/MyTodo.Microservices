
namespace Objectives.API.Objectives.GetObjectiveById;

public record GetObjectiveByIdResponse(ObjectiveDto Objective);

public class DeleteObjectiveEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/objectives/detail/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new GetObjectiveByIdQuery(id, UserConstants.UserId));

            var response = result.Adapt<GetObjectiveByIdResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Objective By Id").
        WithDescription("Get Objective By Id").
        WithSummary("Get Objective By Id").
        Produces<GetObjectiveByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
