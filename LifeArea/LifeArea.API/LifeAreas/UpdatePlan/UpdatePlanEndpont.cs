using Carter;
using Mapster;
using MediatR;

namespace LifeArea.API.LifeAreas.UpdatePlan;

public record UpdatePlanRequest(string Plan);

public record UpdatePlanResponse(bool IsSuccess);

public class UpdatePlanEndpont : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/lifeareas/plan/{id}", async (int id, UpdatePlanRequest request, ISender sender) =>
        {

            var command = new UpdatePlanCommand(id, request.Plan);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdatePlanResponse>();

            return Results.Ok(response);

        }).
        WithName("Update LifeArea Plan").
        WithDescription("Update LifeArea Plan").
        WithSummary("Update LifeArea Plan").
        Produces<UpdatePlanResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
