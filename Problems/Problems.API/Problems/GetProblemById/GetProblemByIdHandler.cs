
using Problems.API.Domain;

namespace Problems.API.Problems.GetProblemById;

public record GetProblemByIdQuery(int Id) : IQuery<GetProblemByIdResult>;

public record GetProblemByIdResult(ProblemDto Problem);

public class GetProblemByIdHandler(IDocumentSession session, ILogger<GetProblemByIdHandler> logger) : IQueryHandler<GetProblemByIdQuery, GetProblemByIdResult>
{
    public async Task<GetProblemByIdResult> Handle(GetProblemByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProblemByIdHandler called with {Id}", query.Id);

        var problem = await session.LoadAsync<Problem>(query.Id, cancellationToken);

        var problemDto = problem.Adapt<ProblemDto>();

        return new GetProblemByIdResult(problemDto);
    }
}
