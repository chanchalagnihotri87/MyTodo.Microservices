using Tasks.Application.Todos.Commands.UpdateTodoItemDate;
using Tasks.Application.Todos.Commands.UpdateTodoItemSprint;

namespace Tasks.API.EndPoints.Todos;

public record UpdateTodoItemDateRequest(string Date);

public record UpdateTodoItemDateResponse(bool IsSuccess);

public class UpdateTodoItemDateEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/todoitems/date/{id}", async (int id, UpdateTodoItemDateRequest request, ISender sender) =>
        {
            var command = new UpdateTodoItemDateCommand(id, string.IsNullOrEmpty(request.Date) ? null : DateTime.Parse(request.Date), UserConstants.UserId);


            var result = await sender.Send(command);

            var response = result.Adapt<UpdateTodoItemDateResponse>();

            return Results.Ok(response);
        }).
        WithName("Update Todo Item Date").
        WithDescription("Update Todo Item Date").
        WithSummary("Update Todo Item Date").
        Produces<UpdateTodoItemDateResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status400BadRequest);
    }
}

