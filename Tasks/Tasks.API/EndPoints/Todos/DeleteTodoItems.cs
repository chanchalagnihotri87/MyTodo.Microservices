
using Tasks.Application.Todos.Commands.DeleteTodoItem;

namespace Tasks.API.EndPoints.Todos;

public record DeleteTodoItemResponse(bool IsSuccess);


public class DeleteTodoItems : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/todoitems/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteTodoItemCommand(id, UserConstants.UserId));

            var response = result.Adapt<DeleteTodoItemResponse>();

            return Results.Ok(response);
        }).
        WithName("Delete Todo Item").
        WithDescription("Delete Todo Item").
        WithSummary("Delete Todo Item").
        Produces<DeleteTodoItemResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
