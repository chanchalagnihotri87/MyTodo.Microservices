using Carter;
using Mapster;
using MediatR;

namespace LifeArea.API.LifeAreas.GetLifeAreas;

public record GetLifeAreasResponse(IEnumerable<LifeAreaType> LifeAreas);

public class GetLifeAreasEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/lifeareas", async (ISender sender) =>
        {
            var result = await sender.Send(new GetLifeAreasQuery());

            var response = result.Adapt<GetLifeAreasResponse>();

            return Results.Ok(response);

        }).
        WithName("GetLifeAreas").
        WithDescription("Get Life Areas").
        WithSummary("Get Life Areas").
        Produces<GetLifeAreasResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
