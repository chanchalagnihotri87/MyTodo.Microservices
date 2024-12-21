
using FluentValidation;
using Sprints.API.Domain;

namespace Sprints.API.Sprints.CreateSprint;

public record CreateSprintCommand(SprintDto Sprint, Guid UserId) : ICommand<CreateSprintResult>;

public record CreateSprintResult(int Id);

public class CreateSprintCommandValidator : AbstractValidator<CreateSprintCommand> {

    public CreateSprintCommandValidator()
    {
        RuleFor(x => x.Sprint.Text).NotEmpty().WithMessage("Text is required.");
    }
}

public class CreateSprintHandler(SprintDbContext dbContext) : ICommandHandler<CreateSprintCommand, CreateSprintResult>
{
    public async Task<CreateSprintResult> Handle(CreateSprintCommand command, CancellationToken cancellationToken)
    {
        var sprint = command.Sprint.Adapt<Sprint>();

        sprint.Id = 0;
        sprint.UserId = command.UserId;
        sprint.StartDate = command.Sprint.StartDate.Date;
        sprint.EndDate = command.Sprint.EndDate.Date;

        dbContext.Add(sprint);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateSprintResult(sprint.Id);
    }
}
