using FluentValidation;

namespace Tasks.Application.Todos.Commands.CreateTodoItem;

public record CreateTodoItemCommand(TodoItemDto TodoItem, Guid UserId):ICommand<CreateTodoItemResult>;

public record CreateTodoItemResult(int Id);

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand> {

    public CreateTodoItemCommandValidator()
    {
        RuleFor(x => x.TodoItem.Text).NotEmpty().WithMessage("TodoItem text is required.");
        RuleFor(x => x.TodoItem.TaskId).GreaterThan(0).WithMessage("Task Id must be greater than 0.");
    }
}