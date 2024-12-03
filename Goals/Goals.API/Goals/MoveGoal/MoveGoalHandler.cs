using Goals.API.Domain;

namespace Goals.API.Goals.MoveGoal;


public record MoveGoalCommand(int Id, int ProblemId, int index, Guid UserId) : ICommand<MoveGoalResult>;

public record MoveGoalResult(bool IsSuccess);

public class MoveGoalHandler(IDocumentSession session) : ICommandHandler<MoveGoalCommand, MoveGoalResult>
{
    public async Task<MoveGoalResult> Handle(MoveGoalCommand command, CancellationToken cancellationToken)
    {
        var goals = await session.Query<Goal>().Where(x => x.UserId == command.UserId && x.ProblemId == command.ProblemId).ToListAsync();

        var draggedGoal = goals.First(x => x.Id == command.Id);

        if (draggedGoal == null)
        {
            throw new NotFoundException("Goal", command.UserId);
        }

        int newIndex = command.index;

        if (newIndex == draggedGoal!.Index)
        {
            return new MoveGoalResult(true);
        }

        if (newIndex < draggedGoal!.Index)
        {
            foreach (var goal in goals.Where(g => g.Index >= newIndex && g.Index <= draggedGoal.Index))
            {
                goal.Index++;
            }
        }
        else
        {
            foreach (var goal in goals.Where(g => g.Index >= draggedGoal.Index && g.Index <= newIndex))
            {
                goal.Index--;
            }
        }

        draggedGoal.Index = newIndex;

        session.Update<Goal>(goals);

        await session.SaveChangesAsync();


        return new MoveGoalResult(true);

    }
}
