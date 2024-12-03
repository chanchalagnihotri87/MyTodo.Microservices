using BuildingBlocks.Exceptions;
using Problems.API.Domain;

namespace Problems.API.Problems.DeleteProblem;

public record DeleteProblemCommand(int Id, Guid UserId) : ICommand<DeleteProblemResult>;

public record DeleteProblemResult(bool IsSuccess);

public class DeleteProblemHandler(IDocumentSession session) : ICommandHandler<DeleteProblemCommand, DeleteProblemResult>
{
    public async Task<DeleteProblemResult> Handle(DeleteProblemCommand command, CancellationToken cancellationToken)
    {
        var problem = await session.LoadAsync<Problem>(command.Id, cancellationToken);

        if (problem == null || problem.User_Id != UserConstants.UserId)
        {
            throw new NotFoundException("Problem", command.Id);
        }

        session.Delete<Problem>(problem);

        await session.SaveChangesAsync();

        return new DeleteProblemResult(true);
    }
}

