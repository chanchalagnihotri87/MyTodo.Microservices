
using Tasks.Application.Todos.Commands.UpdateTodoItem;

namespace Tasks.API.EndPoints.Todos;

public record UpdateTodoItemRequest(TodoItemDto TodoItem);

public record UpdateTodoItemResponse(bool IsSuccess);

public class UpdateTodoItem : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/todoitems", async (UpdateTodoItemRequest request, ISender sender) =>
        {
            var command = new UpdateTodoItemCommand(request.TodoItem, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateTodoItemResponse>();

            return Results.Ok(response);
        }).
        WithName("Update TodoItem").
        WithDescription("Update TodoItem").
        WithSummary("Update TodoItem").
        Produces<UpdateTodoItemResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
