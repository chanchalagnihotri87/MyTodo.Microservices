namespace Objectives.API.Objectives.UpdatePlan;

public record UpdatePlanRequest(string Plan);

public record UpdatePlanResponse(bool IsSuccess);

public class UpdatePlanEndpont : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/objectives/plan/{id}", async (int id, UpdatePlanRequest request, ISender sender) =>
        {
            var command = new UpdatePlanCommand(id, request.Plan, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdatePlanResponse>();

            return Results.Ok(response);

        }).
        WithName("Update Goal Plan").
        WithDescription("Update Goal Plan").
        WithSummary("Update Goal Plan").
        Produces<UpdatePlanResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
