using Problems.API.Data;
using Problems.API.Domain;

namespace Problems.API.Problems.CreateProblem;

public record CreateProblemCommand(ProblemDto Problem, Guid UserId) : ICommand<CreateProblemResult>;

public record CreateProblemResult(int Id);


public class CreateProblemCommandValidator : AbstractValidator<CreateProblemCommand>
{
    public CreateProblemCommandValidator()
    {
        RuleFor(x => x.Problem.Text).NotEmpty().WithMessage("Text is required.");
        RuleFor(x => x.Problem.LifeAreaId).GreaterThan(0).WithMessage("LifeAreaId must be greater than 0.");
    }
}

public class CreateProblemHandler(ProblemDbContext dbContext) : ICommandHandler<CreateProblemCommand, CreateProblemResult>
{
    public async Task<CreateProblemResult> Handle(CreateProblemCommand command, CancellationToken cancellationToken)
    {
        var index = dbContext.Problems.Any(x => x.User_Id == command.UserId && x.LifeAreaId == command.Problem.LifeAreaId) ? dbContext.Problems.Where(x => x.User_Id == command.UserId && x.LifeAreaId == command.Problem.LifeAreaId).Max(x => x.Index) : 1;

        var problem = command.Problem.Adapt<Problem>();

        problem.Id = 0; //Explicitly setting id zero in any case by mistake get id from front end
        problem.User_Id = command.UserId;
        problem.Index = index + 1;


        dbContext.Problems.Add(problem);

        await dbContext.SaveChangesAsync();

        return new CreateProblemResult(problem.Id);
    }
}
