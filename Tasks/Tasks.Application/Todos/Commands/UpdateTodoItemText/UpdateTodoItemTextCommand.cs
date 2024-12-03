using FluentValidation;

namespace Tasks.Application.Todos.Commands.UpdateTodoItemText;

public record UpdateTodoItemTextCommand(int Id, string Text, Guid UserId) : ICommand<UpdateTodoItemTextResult>;

public record UpdateTodoItemTextResult(bool IsSuccess);

public class UpdateObjectiveCommandValidator : AbstractValidator<UpdateTodoItemTextCommand>
{
    public UpdateObjectiveCommandValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required.");
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}