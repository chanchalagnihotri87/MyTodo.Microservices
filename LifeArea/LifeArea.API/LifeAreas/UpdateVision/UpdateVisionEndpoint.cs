using Carter;
using LifeArea.API.LifeAreas.UpdatePlan;
using Mapster;
using MediatR;

namespace LifeArea.API.LifeAreas.UpdateVision;

public record UpdateVisionRequest(string Vision);

public record UpdateVisionResponse(bool IsSuccess);

public class UpdateVisionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/lifeareas/vision/{id}", async (int id, UpdateVisionRequest request, ISender sender) =>
        {

            var command = new UpdateVisionCommand(id, request.Vision);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateVisionResponse>();

            return Results.Ok(response);

        }).
        WithName("Update LifeArea Vision").
        WithDescription("Update LifeArea Vision").
        WithSummary("Update LifeArea Vision").
        Produces<UpdateVisionResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
