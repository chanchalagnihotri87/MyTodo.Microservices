using Problems.API.Domain;

namespace Problems.API.Problems.GetProblems;

public record GetProblemsQuery(int LifeAreaId, Guid UserId) : IQuery<GetProblemsResult>;

public record GetProblemsResult(IEnumerable<ProblemDto> Problems);

public class GetProblemsHandler(IDocumentSession sesson, ILogger<GetProblemsHandler> logger) : IQueryHandler<GetProblemsQuery, GetProblemsResult>
{
    public async Task<GetProblemsResult> Handle(GetProblemsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProblemsHandler called.");

        var problems = await sesson.Query<Problem>().Where(p => p.User_Id == query.UserId && p.LifeAreaId == query.LifeAreaId).ToListAsync();

        var result = problems.Adapt<IEnumerable<ProblemDto>>();

        return new GetProblemsResult(result);
    }
}
