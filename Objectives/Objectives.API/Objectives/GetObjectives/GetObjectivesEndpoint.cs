using Carter;
using Mapster;
using MediatR;
using Objectives.API.Dto;

namespace Objectives.API.Objectives.GetObjectives;

public record GetObjectivesResponse(IEnumerable<ObjectiveDto> Objectives);

public class GetObjectivesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/objectives/{goalId}", async (int goalId, ISender sender) =>
        {
            var result = await sender.Send(new GetObjectivesQuery(goalId));

            var response = result.Adapt<GetObjectivesResponse>();

            return Results.Ok(response);

        }).
        WithName("Get Objectives").
        WithDescription("Get Objectives").
        WithSummary("Get Objectives").
        Produces<GetObjectivesResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
