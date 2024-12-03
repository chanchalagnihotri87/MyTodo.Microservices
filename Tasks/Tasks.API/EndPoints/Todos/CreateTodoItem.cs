
using Tasks.Application.Todos.Commands.CreateTodoItem;

namespace Tasks.API.EndPoints.Todos;

public record CreateTodoItemRequest(TodoItemDto TodoItem);

public record CreateTodoItemResponse(int Id);

public class CreateTodoItem : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/todoitems", async (CreateTodoItemRequest request, ISender sender) =>
        {
         var result=  await sender.Send(new CreateTodoItemCommand(request.TodoItem, UserConstants.UserId));

            var response = result.Adapt<CreateTodoItemResponse>();

            return Results.Created($"/todoitems/detail/{response.Id}", response);
        }).
        WithName("Create Todo Item").
        WithDescription("Create Todo Item").
        WithSummary("Create Todo Item").
        Produces<CreateTodoItemResponse>(StatusCodes.Status201Created).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
