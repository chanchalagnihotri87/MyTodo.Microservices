
namespace Sprints.API.Sprints.CreateSprint;

public record CreateSprintRequest(string Text, string StartDate, string EndDate);

public record CreateSprintResponse(int Id);

public class CreateSprintEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/sprints", async (CreateSprintRequest request, ISender sender) =>
        {
            var command = new CreateSprintCommand(new SprintDto { Text = request.Text, StartDate = DateTime.Parse(request.StartDate), EndDate = DateTime.Parse(request.EndDate) }, UserConstants.UserId);
            var result = await sender.Send(command);

            var response = result.Adapt<CreateSprintResponse>();

            return Results.Ok(response);
        }).
        WithName("Create Sprint").
        WithDescription("Create Sprint").
        WithSummary("Create Sprint").
        Produces<CreateSprintResponse>(StatusCodes.Status201Created).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
