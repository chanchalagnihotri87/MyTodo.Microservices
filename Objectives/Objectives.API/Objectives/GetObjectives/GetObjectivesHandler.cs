using BuildingBlocks.CQRS;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Objectives.API.Data;
using Objectives.API.Domain;
using Objectives.API.Dto;

namespace Objectives.API.Objectives.GetObjectives;

public record GetObjectivesQuery(int GoalId) : IQuery<GetObjectivesResult>;

public record GetObjectivesResult(IEnumerable<ObjectiveDto> Objectives);

public class GetObjectivesHandler(ObjectiveDbContext dbContext) : IQueryHandler<GetObjectivesQuery, GetObjectivesResult>
{
    public async Task<GetObjectivesResult> Handle(GetObjectivesQuery request, CancellationToken cancellationToken)
    {
        var objectives = await dbContext.Objectives.Where(o => o.GoalId == request.GoalId).ToListAsync();

        return new GetObjectivesResult(objectives.Adapt<IEnumerable<ObjectiveDto>>());
    }
}
