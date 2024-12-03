using FluentValidation;

namespace Tasks.Application.Todos.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id, Guid UserId) : ICommand<DeleteTodoItemResult>;

public record DeleteTodoItemResult(bool IsSuccess);

public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
{
    public DeleteTodoItemCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
