using BuildingBlocks.Exceptions;
using Problems.API.Data;
using Problems.API.Domain;

namespace Problems.API.Problems.DeleteProblem;

public record DeleteProblemCommand(int Id, Guid UserId) : ICommand<DeleteProblemResult>;

public record DeleteProblemResult(bool IsSuccess);

public class DeleteProblemHandler(ProblemDbContext context) : ICommandHandler<DeleteProblemCommand, DeleteProblemResult>
{
    public async Task<DeleteProblemResult> Handle(DeleteProblemCommand command, CancellationToken cancellationToken)
    {
        var problem = await context.Problems.FindAsync(command.Id, cancellationToken);

        if (problem == null || problem.User_Id != UserConstants.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        context.Problems.Remove(problem);

        await context.SaveChangesAsync();

        return new DeleteProblemResult(true);
    }
}

