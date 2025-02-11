﻿
using BuildingBlocks.Exceptions;
using Microsoft.EntityFrameworkCore;
using Problems.API.Data;
using Problems.API.Domain;

namespace Problems.API.Problems.MoveProblem;

public record MoveProblemCommand(int Id, int LifeAreaId, int index, Guid UserId) : ICommand<MoveProblemResult>;

public record MoveProblemResult(bool IsSuccess);

public class MoveProblemHandler(ProblemDbContext context) : ICommandHandler<MoveProblemCommand, MoveProblemResult>
{
    public async Task<MoveProblemResult> Handle(MoveProblemCommand command, CancellationToken cancellationToken)
    {
        var problems = await context.Problems.Where(x => x.User_Id == command.UserId && x.LifeAreaId == command.LifeAreaId).ToListAsync();

        var draggedProblem = problems.First(x => x.Id == command.Id);

        if (draggedProblem == null)
        {
            throw new NotFoundException("Problem", command.UserId);
        }

        int newIndex = command.index;

        if (newIndex == draggedProblem!.Index)
        {
            return new MoveProblemResult(true);
        }

        if (newIndex < draggedProblem!.Index)
        {
            foreach (var problem in problems.Where(p => p.Index >= newIndex && p.Index <= draggedProblem.Index))
            {
                problem.Index++;
            }
        }
        else
        {
            foreach (var problem in problems.Where(p => p.Index >= draggedProblem.Index && p.Index <= newIndex))
            {
                problem.Index--;
            }
        }

        draggedProblem.Index = newIndex;

        context.Update(problems);

        await context.SaveChangesAsync();


        return new MoveProblemResult(true);

    }
}
