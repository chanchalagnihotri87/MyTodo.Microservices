using Microsoft.EntityFrameworkCore;
using Tasks.Application.Data;

namespace Tasks.Application.Tasks.Commands.MoveTask;


public class MoveTaskHandler(IApplicationDbContext dbContext) : ICommandHandler<MoveTaskCommand, MoveTaskResult>
{
    public async Task<MoveTaskResult> Handle(MoveTaskCommand command, CancellationToken cancellationToken)
    {
        var tasks = await dbContext.Tasks.Where(x => x.UserId == command.UserId && x.ObjectiveId == command.ObjectiveId).ToListAsync(); ;

        var draggedTask = tasks.First(x => x.Id == command.Id);

        if (draggedTask == null)
        {
            throw new NotFoundException("Task", command.UserId);
        }

        int newIndex = command.index;

        if (newIndex == draggedTask!.Index)
        {
            return new MoveTaskResult(true);
        }

        if (newIndex < draggedTask!.Index)
        {
            foreach (var task in tasks.Where(t => t.Index >= newIndex && t.Index <= draggedTask.Index))
            {
                task.Index++;
            }
        }
        else
        {
            foreach (var task in tasks.Where(t => t.Index >= draggedTask.Index && t.Index <= newIndex))
            {
                task.Index--;
            }
        }

        draggedTask.Index = newIndex;

        dbContext.Tasks.UpdateRange(tasks);

        await dbContext.SaveChangesAsync(cancellationToken);


        return new MoveTaskResult(true);

    }
}
