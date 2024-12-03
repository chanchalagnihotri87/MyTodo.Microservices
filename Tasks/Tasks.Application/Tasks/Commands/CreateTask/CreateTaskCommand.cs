using FluentValidation;

namespace Tasks.Application.Tasks.Commands.CreateTask;

public record CreateTaskCommand(TaskDto Task, Guid UserId) : ICommand<CreateTaskResult>;


public record CreateTaskResult(int Id);


public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Task.Text).NotEmpty().WithMessage("Task Text is required.");
        RuleFor(x => x.Task.ObjectiveId).GreaterThan(0).WithMessage("Task Objective Id must be greater than 0.");
    }
}
