using Tasks.Application.Todos.Commands.MoveTodoItem;

namespace Tasks.API.EndPoints.Todos;
public record MoveTodoItemRequest(int TaskId, int Index);

public record MoveTodoItemResponse(bool IsSuccess);

public class MoveTodoItemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/todoitems/move/{id}", async (int Id, MoveTodoItemRequest request, ISender sender) =>
        {
            var command = new MoveTodoItemCommand(Id, request.TaskId, request.Index, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<MoveTodoItemResponse>();

            return Results.Ok(response);
        }).
        WithName("Move Todo Item").
        WithDescription("Move Todo Item").
        WithSummary("Move Todo Item").
        Produces<MoveTodoItemResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
