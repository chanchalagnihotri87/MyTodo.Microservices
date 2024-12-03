using Tasks.Application.Todos.Commands.UpdateTodoItemText;

namespace Tasks.API.EndPoints.Todos;

public record UpdateTodoItemTextRequest(string Text);

public record UpdateTodoItemTextResponse(bool IsSuccess);

public class UpdateTodoItemTextEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/todoitems/text/{id}", async (int id, UpdateTodoItemTextRequest request, ISender sender) =>
        {
            var command = new UpdateTodoItemTextCommand(id, request.Text, UserConstants.UserId);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateTodoItemTextResponse>();

            return Results.Ok(response);
        }).
        WithName("Update Todo Item Text").
        WithDescription("Update Todo Item Text").
        WithSummary("Update Todo Item Text").
        Produces<UpdateTodoItemTextResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
