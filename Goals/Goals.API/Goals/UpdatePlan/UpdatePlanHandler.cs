
using Goals.API.Data;
using Goals.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Goals.API.Goals.UpdatePlan;

public record UpdatePlanCommand(int Id, string Plan, Guid UserId) : ICommand<UpdatePlanResult>;

public record UpdatePlanResult(bool IsSuccess);

public class UpdatePlanHandler(GoalDbContext dbContext) : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
{
    public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
    {
        var goal = await dbContext.Goals.FindAsync(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        goal.Plan = command.Plan;
        dbContext.Goals.Update(goal);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePlanResult(true);
    }
}
