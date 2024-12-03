using Objectives.API.Domain;

namespace Objectives.API.Objectives.UpdateObjectiveText;

public record UpdateObjectiveTextCommand(int Id, string Text, Guid UserId) : ICommand<UpdateObjectiveTestResult>;

public record UpdateObjectiveTestResult(bool IsSuccess);

public class UpdateObjectiveCommandValidator : AbstractValidator<UpdateObjectiveTextCommand>
{
    public UpdateObjectiveCommandValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required.");
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}

public class UpdateObjectiveTextHandler(IDocumentSession session) : ICommandHandler<UpdateObjectiveTextCommand, UpdateObjectiveTestResult>
{
    public async Task<UpdateObjectiveTestResult> Handle(UpdateObjectiveTextCommand command, CancellationToken cancellationToken)
    {
        var objective = await session.LoadAsync<Objective>(command.Id, cancellationToken);

        if (objective == null || objective.UserId != command.UserId)
        {
            throw new NotFoundException("Objective", command.Id);
        }

        objective.Text = command.Text;

        session.Update<Objective>(objective);

        await session.SaveChangesAsync();

        return new UpdateObjectiveTestResult(true);
    }
}
