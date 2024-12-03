
using Tasks.Application.Todos.Commands.ToggleTwentyPercent;

namespace Tasks.API.EndPoints.Todos;

public record ToggleTwentyPercentRequest(bool TwentyPercent);

public record ToggleTwentyPercentResponse(bool IsSuccess);

public class ToggleTwentyPercentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/todoitems/twentypercent/{id}", async (int id, ToggleTwentyPercentRequest request, ISender sender) =>
        {
            var command = new ToggleTwentyPercentCommand(id, request.TwentyPercent, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<ToggleTwentyPercentResponse>();

            return Results.Ok(response);
        }).
        WithName("Toggle Todo Item 20%").
        WithDescription("Toggle Todo Item 20%").
        WithSummary("Toggle Todo Item 20%").
        Produces<ToggleTwentyPercentResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
