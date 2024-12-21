
using FluentValidation;
using Goals.API.Data;
using Goals.API.Domain;

namespace Goals.API.Goals.UpdateGoalText;

public record UpdateGoalTextCommand(int Id, string Text, Guid UserId) : ICommand<UpdateGoalTestResult>;

public record UpdateGoalTestResult(bool IsSuccess);

public class UpdateGoalCommandValidator : AbstractValidator<UpdateGoalTextCommand>
{
    public UpdateGoalCommandValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Goal text is required.");
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Goal Id must be greater than 0.");
    }
}

public class UpdateGoalTextHandler(GoalDbContext dbContext) : ICommandHandler<UpdateGoalTextCommand, UpdateGoalTestResult>
{
    public async Task<UpdateGoalTestResult> Handle(UpdateGoalTextCommand command, CancellationToken cancellationToken)
    {
        var goal = await dbContext.Goals.FindAsync(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        goal.Text = command.Text;

        dbContext.Goals.Update(goal);

        await dbContext.SaveChangesAsync();

        return new UpdateGoalTestResult(true);
    }
}
