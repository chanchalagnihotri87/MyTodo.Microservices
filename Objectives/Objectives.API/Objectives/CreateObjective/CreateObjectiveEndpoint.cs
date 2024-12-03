using Carter;
using Mapster;
using MediatR;
namespace Objectives.API.Objectives.CreateObjective;

public record CreateObjectiveRequest(ObjectiveDto Objective);

public record CreateObjectiveResponse(int Id);

public class CreateObjectiveEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/objectives", async (CreateObjectiveRequest request, ISender sender) =>
        {
            var command = new CreateObjectiveCommand(request.Objective, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<CreateObjectiveResponse>();

            return Results.Created($"/objectives/detail/{response.Id}", response.Id);
        }).
        WithName("Create Objective").
        WithDescription("Create Objective").
        WithSummary("Create Objective").
        Produces<CreateObjectiveResponse>(StatusCodes.Status201Created).
        ProducesProblem(StatusCodes.Status400BadRequest);

    }
}
