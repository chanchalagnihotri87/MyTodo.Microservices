
using Microsoft.EntityFrameworkCore;

namespace Sprints.API.Sprints.GetSprints;

public record GetSprintsQuery(Guid UserId) : IQuery<GetSprintsResult>;

public record GetSprintsResult(IEnumerable<SprintDto> Sprints);

public class GetSprintsHandler(SprintDbContext dbContext) : IQueryHandler<GetSprintsQuery, GetSprintsResult>
{
    public async Task<GetSprintsResult> Handle(GetSprintsQuery query, CancellationToken cancellationToken)
    {
        var sprints = await dbContext.Sprints.Where(x => x.UserId == query.UserId).ToListAsync();

        return new GetSprintsResult(sprints.Adapt<IEnumerable<SprintDto>>());
    }
}
