
using FluentValidation;
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

public class UpdateGoalTextHandler(IDocumentSession session) : ICommandHandler<UpdateGoalTextCommand, UpdateGoalTestResult>
{
    public async Task<UpdateGoalTestResult> Handle(UpdateGoalTextCommand command, CancellationToken cancellationToken)
    {
        var goal = await session.LoadAsync<Goal>(command.Id, cancellationToken);

        if (goal == null || goal.UserId != command.UserId)
        {
            throw new NotFoundException("Goal", command.Id);
        }

        goal.Text = command.Text;

        session.Update<Goal>(goal);

        await session.SaveChangesAsync();

        return new UpdateGoalTestResult(true);
    }
}
