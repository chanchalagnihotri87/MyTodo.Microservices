﻿
using BuildingBlocks.Exceptions;
using Problems.API.Domain;

namespace Problems.API.Problems.UpdateProblemText;

public record UpdateProblemTextCommand(int Id, string Text, Guid UserId) : ICommand<UpdateProblemTextResult>;

public record UpdateProblemTextResult(bool IsSuccess);

public class UpdateProblemCommandValidator : AbstractValidator<UpdateProblemTextCommand>
{
    public UpdateProblemCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id should be greater than 0.");
        RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required.");
    }
}

public class UpdateProblemNameHandler(IDocumentSession session) : ICommandHandler<UpdateProblemTextCommand, UpdateProblemTextResult>
{
    public async Task<UpdateProblemTextResult> Handle(UpdateProblemTextCommand command, CancellationToken cancellationToken)
    {
        var problem = await session.LoadAsync<Problem>(command.Id, cancellationToken);

        if (problem == null || problem.User_Id != command.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        problem.Text = command.Text;

        session.Update<Problem>(problem);

        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProblemTextResult(true);
    }
}
