using FluentValidation;


namespace Sprints.API.Sprints.UpdateSprint;

public record UpdateSprintCommand(SprintDto Sprint, Guid UserId) : ICommand<UpdateSprintResult>;

public record UpdateSprintResult(bool IsSuccess);

public class UpdateSprintCommandValidator : AbstractValidator<UpdateSprintCommand>
{
    public UpdateSprintCommandValidator()
    {
        RuleFor(x => x.Sprint.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.Sprint.Text).NotEmpty().WithMessage("Text is required.");
    }
}

public class UpdateSprintHandler(SprintDbContext dbContext) : ICommandHandler<UpdateSprintCommand, UpdateSprintResult>
{
    public async Task<UpdateSprintResult> Handle(UpdateSprintCommand command, CancellationToken cancellationToken)
    {
        var sprint = await dbContext.Sprints.FindAsync(command.Sprint.Id, cancellationToken);

        if (sprint == null || sprint.UserId != command.UserId)
        {
            throw new NotFoundException("Sprint", command.Sprint.Id);
        }

        sprint.Text = command.Sprint.Text;
        sprint.StartDate = command.Sprint.StartDate.Date;
        sprint.EndDate = command.Sprint.EndDate.Date;

        dbContext.Sprints.Update(sprint);

        await dbContext.SaveChangesAsync();

        return new UpdateSprintResult(true);
    }
}
