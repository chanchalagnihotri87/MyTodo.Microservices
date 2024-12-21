using Microsoft.EntityFrameworkCore;
using Problems.API.Data;
using Problems.API.Domain;

namespace Problems.API.Problems.GetProblems;

public record GetProblemsQuery(int LifeAreaId, Guid UserId) : IQuery<GetProblemsResult>;

public record GetProblemsResult(IEnumerable<ProblemDto> Problems);

public class GetProblemsHandler(ProblemDbContext dbContext, ILogger<GetProblemsHandler> logger) : IQueryHandler<GetProblemsQuery, GetProblemsResult>
{
    public async Task<GetProblemsResult> Handle(GetProblemsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProblemsHandler called.");

        var problems = await dbContext.Problems.Where(p => p.User_Id == query.UserId && p.LifeAreaId == query.LifeAreaId).ToHashSetAsync();

        var result = problems.Adapt<IEnumerable<ProblemDto>>();

        return new GetProblemsResult(result);
    }
}
