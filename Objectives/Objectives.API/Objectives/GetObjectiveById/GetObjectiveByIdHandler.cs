
using Objectives.API.Domain;

namespace Objectives.API.Objectives.GetObjectiveById;

public record GetObjectiveByIdQuery(int Id, Guid UserId) : IQuery<GetObjectiveByIdResult>;

public record GetObjectiveByIdResult(ObjectiveDto Objective);

public class DeleteObjectiveHandler(IDocumentSession session) : IQueryHandler<GetObjectiveByIdQuery, GetObjectiveByIdResult>
{
    public async Task<GetObjectiveByIdResult> Handle(GetObjectiveByIdQuery query, CancellationToken cancellationToken)
    {
        var objective = await session.LoadAsync<Objective>(query.Id, cancellationToken);

        if (objective == null || objective.UserId != query.UserId)
        {
            throw new NotFoundException("Objective", query.Id);
        }

        return new GetObjectiveByIdResult(objective.Adapt<ObjectiveDto>());
    }
}
