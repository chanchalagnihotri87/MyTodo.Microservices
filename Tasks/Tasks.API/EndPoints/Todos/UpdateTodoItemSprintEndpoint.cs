using Tasks.Application.Todos.Commands.UpdateTodoItemSprint;

namespace Tasks.API.EndPoints.Todos;

public record UpdateTodoItemSprintRequest(int? SprintId);

public record UpdateTodoItemSprintResponse(bool IsSuccess);

public class UpdateTodoItemSprintEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/todoitems/sprint/{id}", async (int id, UpdateTodoItemSprintRequest request, ISender sender) =>
        {
            var command = new UpdateTodoItemSprintCommand(id, request.SprintId, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateTodoItemSprintResponse>();

            return Results.Ok(response);
        }).
        WithName("Update Todo Item Sprint").
        WithDescription("Update Todo Item Sprint").
        WithSummary("Update Todo Item Sprint").
        Produces<UpdateTodoItemSprintResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
