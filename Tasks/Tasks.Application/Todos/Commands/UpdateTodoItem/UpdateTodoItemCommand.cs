using FluentValidation;

namespace Tasks.Application.Todos.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand(TodoItemDto TodoItem, Guid UserId) : ICommand<UpdateTodoItemResult>;

public record UpdateTodoItemResult(bool IsSuccess);

public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(x => x.TodoItem.Id).GreaterThan(0).WithMessage("TodoItem Id must be greater than 0.");
        RuleFor(x => x.TodoItem.Text).NotEmpty().WithMessage("TodoItem text is required.");
        RuleFor(x => x.TodoItem.TaskId).GreaterThan(0).WithMessage("Task Id must be greater than 0.");
    }
}
