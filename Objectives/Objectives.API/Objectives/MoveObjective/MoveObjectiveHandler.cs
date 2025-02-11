﻿
using Microsoft.EntityFrameworkCore;
using Objectives.API.Data;
using Objectives.API.Domain;

namespace Objectives.API.Objectives.MoveGoal;


public record MoveObjectiveCommand(int Id, int GoalId, int index, Guid UserId) : ICommand<MoveObjectiveResult>;

public record MoveObjectiveResult(bool IsSuccess);

public class MoveObjectiveHandler(ObjectiveDbContext dbContext) : ICommandHandler<MoveObjectiveCommand, MoveObjectiveResult>
{
    public async Task<MoveObjectiveResult> Handle(MoveObjectiveCommand command, CancellationToken cancellationToken)
    {
        var objectives = await dbContext.Objectives.Where(x => x.UserId == command.UserId && x.GoalId == command.GoalId).ToListAsync();

        var draggedObjective = objectives.First(x => x.Id == command.Id);

        if (draggedObjective == null)
        {
            throw new NotFoundException("Objective", command.UserId);
        }

        int newIndex = command.index;

        if (newIndex == draggedObjective!.Index)
        {
            return new MoveObjectiveResult(true);
        }

        if (newIndex < draggedObjective!.Index)
        {
            foreach (var objective in objectives.Where(o => o.Index >= newIndex && o.Index <= draggedObjective.Index))
            {
                objective.Index++;
            }
        }
        else
        {
            foreach (var objective in objectives.Where(o => o.Index >= draggedObjective.Index && o.Index <= newIndex))
            {
                objective.Index--;
            }
        }

        draggedObjective.Index = newIndex;

        dbContext.Objectives.UpdateRange(objectives);

        await dbContext.SaveChangesAsync();


        return new MoveObjectiveResult(true);

    }
}
