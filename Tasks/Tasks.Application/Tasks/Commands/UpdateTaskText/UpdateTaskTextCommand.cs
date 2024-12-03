using FluentValidation;

namespace Tasks.Application.Tasks.Commands.UpdateObjectiveText;

public record UpdateTaskTextCommand(int Id, string Text, Guid UserId) : ICommand<UpdateTaskTexttResult>;

public record UpdateTaskTexttResult(bool IsSuccess);

public class UpdateObjectiveCommandValidator : AbstractValidator<UpdateTaskTextCommand>
{
    public UpdateObjectiveCommandValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required.");
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}