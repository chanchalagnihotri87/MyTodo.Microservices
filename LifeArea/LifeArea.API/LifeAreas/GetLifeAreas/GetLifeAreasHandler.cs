using BuildingBlocks.CQRS;
using LifeArea.API.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeArea.API.LifeAreas.GetLifeAreas;

public record GetLifeAreasQuery : IQuery<GetLifeAreasResult>;

public record GetLifeAreasResult(IEnumerable<LifeAreaType> LifeAreas);



public class GetLifeAreasHandler(ILogger<GetLifeAreasHandler> logger, LifeAreaDbContext dbContext) : IQueryHandler<GetLifeAreasQuery, GetLifeAreasResult>
{
    public async Task<GetLifeAreasResult> Handle(GetLifeAreasQuery query, CancellationToken cancellationToken)
    {
        var lifeAreas = await dbContext.LifeAreas.ToListAsync();

        return new GetLifeAreasResult(lifeAreas);
    }
}
