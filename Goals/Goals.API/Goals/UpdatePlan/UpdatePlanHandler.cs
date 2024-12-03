
using Goals.API.Domain;

namespace Goals.API.Goals.UpdatePlan;

public record UpdatePlanCommand(int Id, string Plan, Guid UserId) : ICommand<UpdatePlanResult>;

public record UpdatePlanResult(bool IsSuccess);

public class UpdatePlanHandler(IDocumentSession session) : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
{
    public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
    {
        var goal = await session.LoadAsync<Goal>(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        goal.Plan = command.Plan;

        session.Update<Goal>(goal);

        await session.SaveChangesAsync(cancellationToken);

        return new UpdatePlanResult(true);
    }
}
