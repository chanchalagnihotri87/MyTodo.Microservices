
namespace Sprints.API.Sprints.UpdateSprint;

public record UpdateSprintRequest(int Id, string Text, string StartDate, string EndDate);

public record UpdateSprintResponse(bool IsSuccess);

public class UpdateSprintEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/sprints", async (UpdateSprintRequest request, ISender sender) =>
        {
            var command = new UpdateSprintCommand(new SprintDto { Id = request.Id, Text = request.Text, StartDate = DateTime.Parse(request.StartDate), EndDate = DateTime.Parse(request.EndDate) }, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateSprintResponse>();

            return Results.Ok(response);

        }).WithName("Update Sprint").
        WithDescription("Update Sprint").
        WithDescription("Update Sprint").
        Produces<UpdateSprintResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
