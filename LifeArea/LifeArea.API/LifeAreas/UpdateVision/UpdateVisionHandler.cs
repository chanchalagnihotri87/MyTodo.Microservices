
using BuildingBlocks.Exceptions;
using LifeArea.API.Data;
using LifeArea.API.LifeAreas.UpdatePlan;
using Microsoft.EntityFrameworkCore;

namespace LifeArea.API.LifeAreas.UpdateVision;

public record UpdateVisionCommand(int Id, string Vision) : ICommand<UpdateVisionResult>;

public record UpdateVisionResult(bool IsSuccess);

public class UpdateVisionHandler(LifeAreaDbContext dbContext) : ICommandHandler<UpdateVisionCommand, UpdateVisionResult>
{
    public async Task<UpdateVisionResult> Handle(UpdateVisionCommand command, CancellationToken cancellationToken)
    {
        var lifeArea = await dbContext.LifeAreas.FindAsync(command.Id);

        if (lifeArea == null)
        {
            throw new NotFoundException("LifeArea", command.Id);
        }

        lifeArea.Vision = command.Vision;

        dbContext.LifeAreas.Update(lifeArea);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateVisionResult(true);
    }
}
