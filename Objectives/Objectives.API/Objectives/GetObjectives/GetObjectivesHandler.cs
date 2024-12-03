using BuildingBlocks.CQRS;
using Mapster;
using Marten;
using Objectives.API.Domain;
using Objectives.API.Dto;

namespace Objectives.API.Objectives.GetObjectives;

public record GetObjectivesQuery(int GoalId) : IQuery<GetObjectivesResult>;

public record GetObjectivesResult(IEnumerable<ObjectiveDto> Objectives);

public class GetObjectivesHandler(IDocumentSession session) : IQueryHandler<GetObjectivesQuery, GetObjectivesResult>
{
    public async Task<GetObjectivesResult> Handle(GetObjectivesQuery request, CancellationToken cancellationToken)
    {
        var objectives = await session.Query<Objective>().Where(o => o.GoalId == request.GoalId).ToListAsync();

        return new GetObjectivesResult(objectives.Adapt<IEnumerable<ObjectiveDto>>());
    }
}
