using Objectives.API.Data;
using Objectives.API.Domain;

namespace Objectives.API.Objectives.UpdatePlan;

public record UpdatePlanCommand(int Id, string Plan, Guid UserId) : ICommand<UpdatePlanResult>;

public record UpdatePlanResult(bool IsSuccess);

public class UpdatePlanHandler(ObjectiveDbContext dbContext) : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
{
    public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
    {
        var objective = await dbContext.Objectives.FindAsync(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Objective", command.Id);
        }

        objective.Plan = command.Plan;

        dbContext.Objectives.Update(objective);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePlanResult(true);
    }
}
