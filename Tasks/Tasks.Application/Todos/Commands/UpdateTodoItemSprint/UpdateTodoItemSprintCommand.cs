using FluentValidation;

namespace Tasks.Application.Todos.Commands.UpdateTodoItemSprint;

public record UpdateTodoItemSprintCommand(int Id, int? SprintId, Guid UserId) : ICommand<UpdateTodoItemTextResult>;

public record UpdateTodoItemTextResult(bool IsSuccess);

public class UpdateSprintCommandValidator : AbstractValidator<UpdateTodoItemSprintCommand>
{
    public UpdateSprintCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}