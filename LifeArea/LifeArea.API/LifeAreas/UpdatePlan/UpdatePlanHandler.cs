using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using LifeArea.API.Data;

namespace LifeArea.API.LifeAreas.UpdatePlan;

public record UpdatePlanCommand(int Id, string Plan) : ICommand<UpdatePlanResult>;

public record UpdatePlanResult(bool IsSuccess);

public class UpdatePlanHandler(LifeAreaDbContext dbContext) : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
{
    public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
    {
        var lifeArea = await dbContext.LifeAreas.FindAsync(command.Id);

        if (lifeArea == null)
        {

            throw new NotFoundException("LifeArea", command.Id);
        }

        lifeArea.Plan = command.Plan;

        dbContext.LifeAreas.Update(lifeArea);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePlanResult(true);
    }
}
