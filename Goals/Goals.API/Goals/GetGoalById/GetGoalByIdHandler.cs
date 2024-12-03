using Goals.API.Domain;

namespace Goals.API.Goals.GetGoalById;

public record GetGoalByIdQuery(int Id, Guid UserId) : IQuery<GetGoalByIdResult>;

public record GetGoalByIdResult(GoalDto Goal);

public class GetGoalByIdHandler(IDocumentSession session) : IQueryHandler<GetGoalByIdQuery, GetGoalByIdResult>
{
    public async Task<GetGoalByIdResult> Handle(GetGoalByIdQuery query, CancellationToken cancellationToken)
    {
        var goal = await session.LoadAsync<Goal>(query.Id, cancellationToken);

        if (goal == null || goal.UserId != query.UserId)
        {
            throw new NotFoundException("Goal", query.Id);
        }

        return new GetGoalByIdResult(goal.Adapt<GoalDto>());
    }
}
