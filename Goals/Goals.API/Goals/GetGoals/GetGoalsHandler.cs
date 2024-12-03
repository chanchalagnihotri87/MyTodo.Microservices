using Goals.API.Domain;

namespace Goals.API.Goals.GetGoals;

public record GetGoalsQuery(int problemId, Guid UserId) : IQuery<GetGoalsResult>;

public record GetGoalsResult(IEnumerable<GoalDto> Goals);

public class GetGoalsHandler(IDocumentSession session) : IQueryHandler<GetGoalsQuery, GetGoalsResult>
{
    public async Task<GetGoalsResult> Handle(GetGoalsQuery query, CancellationToken cancellationToken)
    {
        var goals = await session.Query<Goal>().Where(g => g.UserId == query.UserId && g.ProblemId == query.problemId).ToListAsync();

        return new GetGoalsResult(goals.Adapt<List<GoalDto>>());
    }
}
