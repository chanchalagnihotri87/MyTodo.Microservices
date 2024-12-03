using Mapster;
using Sprints.API.Domain;

namespace Sprints.API.Sprints.GetSprints;

public record GetSprintsQuery(Guid UserId) : IQuery<GetSprintsResult>;

public record GetSprintsResult(IEnumerable<SprintDto> Sprints);

public class GetSprintsHandler(IDocumentSession session) : IQueryHandler<GetSprintsQuery, GetSprintsResult>
{
    public async Task<GetSprintsResult> Handle(GetSprintsQuery query, CancellationToken cancellationToken)
    {
        var sprints = await session.Query<Sprint>().Where(x => x.UserId == query.UserId).ToListAsync();

        return new GetSprintsResult(sprints.Adapt<IEnumerable<SprintDto>>());
    }
}
