using BuildingBlocks.Helper;
using Carter;
using Mapster;
using MediatR;
using Tasks.Application.Dto;
using Tasks.Application.Tasks.Queries;
using Tasks.Application.Tasks.Queries.GetTasks;

namespace Tasks.API.EndPoints.Tasks;

public record GetTasksResponse(IEnumerable<TaskDto> Tasks);

public class GetTasks : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/tasks/{objectiveId}", async (int objectiveId, ISender sender) =>
        {
            var result = await sender.Send(new GetTasksQuery(objectiveId, UserConstants.UserId));

            var response = result.Adapt<GetTasksResponse>();

            return Results.Ok(response);

        }).
        WithName("Get Tasks").
        WithDescription("Get Tasks").
        WithSummary("Get Tasks").
        Produces<GetTasksResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
