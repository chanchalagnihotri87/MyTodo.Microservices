
using FluentValidation;

namespace Tasks.Application.Todos.Commands.UpdateTodoItemDate;

public record UpdateTodoItemDateCommand(int Id, DateTime? Date, Guid UserId) : ICommand<UpdateTodoItemDateResult>;

public record UpdateTodoItemDateResult(bool IsSuccess);

public class UpdateDateCommandValidator : AbstractValidator<UpdateTodoItemDateCommand>
{
    public UpdateDateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}