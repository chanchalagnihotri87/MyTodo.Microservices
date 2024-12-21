using FluentValidation;
using Goals.API.Data;
using Goals.API.Domain;

namespace Goals.API.Goals.CreateGoal;

public record CreateGoalCommand(GoalDto Goal, Guid UserId) : ICommand<CreateGoalResult>;

public record CreateGoalResult(int Id);


public class CreateGoalCommandValidator : AbstractValidator<CreateGoalCommand>
{
    public CreateGoalCommandValidator()
    {
        RuleFor(x => x.Goal.Text).NotEmpty().WithMessage("Goal text is required.");
        RuleFor(x => x.Goal.ProblemId).GreaterThan(0).WithMessage("Problem id must be greater than 0.");
    }
}
public class CreateGoalHandler(GoalDbContext dbContext) : ICommandHandler<CreateGoalCommand, CreateGoalResult>
{
    public async Task<CreateGoalResult> Handle(CreateGoalCommand command, CancellationToken cancellationToken)
    {
        var index = dbContext.Goals.Any(x => x.UserId == command.UserId && x.ProblemId == command.Goal.ProblemId) ? dbContext.Goals.Where(x => x.UserId == command.UserId && x.ProblemId == command.Goal.ProblemId).Max(x => x.Index) : 0;

        Goal goal = command.Goal.Adapt<Goal>();

        goal.Id = 0;
        goal.UserId = command.UserId;
        goal.Index = index + 1;

        dbContext.Goals.Add(goal);

        await dbContext.SaveChangesAsync();

        return new CreateGoalResult(goal.Id);

    }
}
