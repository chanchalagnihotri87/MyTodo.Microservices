
namespace Sprints.API.Sprints.GetSprintById;

public record GetSprintByIdQuery(int Id, Guid UserId) : IQuery<GetSprintByIdResult>;

public record GetSprintByIdResult(SprintDto Sprint);

public class GetSprintByIdHandler(SprintDbContext dbContext) : IQueryHandler<GetSprintByIdQuery, GetSprintByIdResult>
{
    public async Task<GetSprintByIdResult> Handle(GetSprintByIdQuery request, CancellationToken cancellationToken)
    {
        var sprint = await dbContext.Sprints.FindAsync(request.Id, cancellationToken);

        if (sprint == null || sprint.UserId != request.UserId)
        {
            throw new NotFoundException("Sprint", request.Id);
        }

        return new GetSprintByIdResult(sprint.Adapt<SprintDto>());
    }
}
