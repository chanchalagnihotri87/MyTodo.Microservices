
using Tasks.API.EndPoints.Tasks;
using Tasks.Application.Todos.Queries.GetTodoItems;

namespace Tasks.API.EndPoints.Todos;

public record GetTodoItemsResponse(IEnumerable<TodoItemDto> TodoItems);

public class GetTodoItems : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/todoitems/{taskId}", async (int taskId, ISender sender) =>
        {
            var result = await sender.Send(new GetTodoItemsQuery(taskId, UserConstants.UserId));

            var response = result.Adapt<GetTodoItemsResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Todo Items").
        WithDescription("Get Todo Items").
        WithSummary("Get Todo Items").
        Produces<GetTasksResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
