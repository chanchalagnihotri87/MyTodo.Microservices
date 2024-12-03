namespace Problems.API.Problems.DeleteProblem;

public record DeleteProblemResponse(bool IsSuccess);

public class DeleteProblemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/problems/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProblemCommand(id, UserConstants.UserId));

            var response = result.Adapt<DeleteProblemResponse>();

            return Results.Ok(response);

        }).
        WithName("Delete Problem").
        WithDescription("Delete Problem").
        WithSummary("Delete Problem").
        Produces<DeleteProblemResponse>(StatusCodes.Status200OK).
        ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
