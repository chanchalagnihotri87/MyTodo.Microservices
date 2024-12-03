using Tasks.Application.Tasks.Commands.DeleteTask;
using Tasks.Application.Tasks.Queries.GetTaskById;

namespace Tasks.API.EndPoints.Tasks;

public record GetTaskByIdResponse(TaskDto Task);

public class GetTaskById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/tasks/detail/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new GetTaskByIdQuery(id, UserConstants.UserId));

            var response = result.Adapt<GetTaskByIdResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Task By Id").
        WithDescription("Get Task By Id").
        WithSummary("Get Task By Id").
        Produces<GetTaskByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
