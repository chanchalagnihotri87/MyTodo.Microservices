using BuildingBlocks.CQRS;
using LifeArea.API.Data;

namespace LifeArea.API.LifeAreas.GetLifeAreaById;

public record GetLifeAreaByIdQuery(int Id) : IQuery<GetLifeAreaByIdResult>;

public record GetLifeAreaByIdResult(LifeAreaType LifeArea);


public class GetLifeAreaByIdHandler(LifeAreaDbContext dbContext) : IQueryHandler<GetLifeAreaByIdQuery, GetLifeAreaByIdResult>
{
    public async Task<GetLifeAreaByIdResult> Handle(GetLifeAreaByIdQuery query, CancellationToken cancellationToken)
    {
      var lifeArea= await dbContext.LifeAreas.FindAsync(query.Id);

        return new GetLifeAreaByIdResult(lifeArea);
    }
}

