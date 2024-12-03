﻿namespace Problems.API.Problems.UpdatePlan;

public record UpdatePlanRequest(string Plan);

public record UpdatePlanResponse(bool IsSuccess);

public class UpdatePlanEndpont : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/problems/plan/{id}", async (int id, UpdatePlanRequest request, ISender sender) =>
        {

            var command = new UpdatePlanCommand(id, request.Plan, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdatePlanResponse>();

            return Results.Ok(response);

        }).
        WithName("Update Problem Plan").
        WithDescription("Update Problem Plan").
        WithSummary("Update Problem Plan").
        Produces<UpdatePlanResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
