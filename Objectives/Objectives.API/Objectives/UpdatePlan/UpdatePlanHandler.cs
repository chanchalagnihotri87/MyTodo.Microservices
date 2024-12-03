using Objectives.API.Domain;

namespace Objectives.API.Objectives.UpdatePlan;

public record UpdatePlanCommand(int Id, string Plan, Guid UserId) : ICommand<UpdatePlanResult>;

public record UpdatePlanResult(bool IsSuccess);

public class UpdatePlanHandler(IDocumentSession session) : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
{
    public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
    {
        var objective = await session.LoadAsync<Objective>(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Objective", command.Id);
        }

        objective.Plan = command.Plan;

        session.Update<Objective>(objective);

        await session.SaveChangesAsync(cancellationToken);

        return new UpdatePlanResult(true);
    }
}
