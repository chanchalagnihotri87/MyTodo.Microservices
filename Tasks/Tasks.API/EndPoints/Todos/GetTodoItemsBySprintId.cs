
using Tasks.API.EndPoints.Tasks;
using Tasks.Application.Todos.Queries.GetTodoItems;

namespace Tasks.API.EndPoints.Todos;

public record GetTodoItemsBySprintIdResponse(IEnumerable<TodoItemDto> TodoItems);

public class GetTodoItemsBySprintId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/todoitems/sprint/{sprintId}", async (int sprintId, ISender sender) =>
        {
            var result = await sender.Send(new GetTodoItemsBySprintIdQuery(sprintId, UserConstants.UserId));

            var response = result.Adapt<GetTodoItemsBySprintIdResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Todo Items By Sprint Id").
        WithDescription("Get Todo Items By Sprint Id").
        WithSummary("Get Todo Items By Sprint Id").
        Produces<GetTodoItemsBySprintIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
