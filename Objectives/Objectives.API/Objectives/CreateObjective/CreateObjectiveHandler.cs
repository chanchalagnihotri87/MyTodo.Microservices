using Objectives.API.Domain;

namespace Objectives.API.Objectives.CreateObjective;

public record CreateObjectiveCommand(ObjectiveDto Objective, Guid UserId) : ICommand<CreateObjectiveResult>;
public record CreateObjectiveResult(int Id);

public class CreateObjectiveCommandValidator : AbstractValidator<CreateObjectiveCommand>
{
    public CreateObjectiveCommandValidator()
    {
        RuleFor(x => x.Objective.Text).NotEmpty().WithMessage("Object text is required.");
        RuleFor(x => x.Objective.GoalId).GreaterThan(0).WithMessage("Objective goal id must be greater than 0.");
    }
}

public class CreateObjectiveHandler(IDocumentSession session) : ICommandHandler<CreateObjectiveCommand, CreateObjectiveResult>
{
    public async Task<CreateObjectiveResult> Handle(CreateObjectiveCommand command, CancellationToken cancellationToken)
    {
        var index = session.Query<Objective>().Where(x => x.UserId == command.UserId && x.GoalId == command.Objective.GoalId).Max(x => x.Index);

        var objective = command.Objective.Adapt<Objective>();

        objective.Id = 0;
        objective.UserId = command.UserId;
        objective.Index = index + 1;

        session.Store<Objective>(objective);
        await session.SaveChangesAsync();

        return new CreateObjectiveResult(objective.Id);
    }
}
