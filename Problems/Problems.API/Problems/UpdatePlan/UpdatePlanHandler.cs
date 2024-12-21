using Problems.API.Data;
using Problems.API.Domain;


namespace Problems.API.Problems.UpdatePlan;

public record UpdatePlanCommand(int Id, string Plan, Guid UserId) : ICommand<UpdatePlanResult>;

public record UpdatePlanResult(bool IsSuccess);

public class UpdatePlanHandler(ProblemDbContext dbContext) : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
{
    public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
    {
        var problem = await dbContext.Problems.FindAsync(command.Id, cancellationToken);

        if (problem == null || problem.User_Id != command.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        problem.Plan = command.Plan;

        dbContext.Problems.Update(problem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePlanResult(true);
    }
}
