using Carter;
using Mapster;
using MediatR;

namespace LifeArea.API.LifeAreas.GetLifeAreaById;

public record GetLifeAreaByIdResponse(LifeAreaType LifeArea);

public class GetLifeAreaByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/lifeareas/detail/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new GetLifeAreaByIdQuery(id));

            var response = result.Adapt<GetLifeAreaByIdResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Life Area By Id").
        WithDescription("Get Life Area By Id").
        WithSummary("Get Life Area By Id").
        Produces<GetLifeAreaByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
