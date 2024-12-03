
using Tasks.Application.Todos.Queries.GetTodItemById;

namespace Tasks.API.EndPoints.Todos;

public record GetTodoItemByIdResponse(TodoItemDto TodoItem);

public class GetTodoItemById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/todoitems/detail/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new GetTodoItemByIdQuery(id, UserConstants.UserId));

            var response = result.Adapt<GetTodoItemByIdResponse>();

            return Results.Ok(response);
        }).
        WithName("Get Todo Item By Id").
        WithDescription("Get Todo Item By Id").
        WithSummary("Get Todo Item By Id").
        Produces<GetTodoItemByIdResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
