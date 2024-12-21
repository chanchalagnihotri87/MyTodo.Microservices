using BuildingBlocks.Exceptions;
using Microsoft.EntityFrameworkCore;
using Problems.API.Data;
using Problems.API.Domain;
namespace Problems.API.Problems.ToggleTwentyPercent;

public record ToggleTwentyPercentCommand(int Id, bool TwentyPercent, Guid UserId) : ICommand<ToggleTwentyPercentResult>;

public record ToggleTwentyPercentResult(bool IsSuccess);

public class ToggleTwentyPercentHandler(ProblemDbContext context) : ICommandHandler<ToggleTwentyPercentCommand, ToggleTwentyPercentResult>
{
    public async Task<ToggleTwentyPercentResult> Handle(ToggleTwentyPercentCommand command, CancellationToken cancellationToken)
    {
        var problem = await context.Problems.FindAsync(command.Id, cancellationToken);

        if (problem == null || problem.User_Id != command.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        problem.TwentyPercent = command.TwentyPercent;

        context.Update(problem);

        await context.SaveChangesAsync(cancellationToken);

        return new ToggleTwentyPercentResult(true);
    }
}
