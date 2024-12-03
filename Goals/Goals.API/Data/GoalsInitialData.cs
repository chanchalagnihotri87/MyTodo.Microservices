using Goals.API.Domain;
using Marten.Schema;
using System.Net.Sockets;

namespace Goals.API.Data;

public class GoalsInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Goal>().AnyAsync())
        {
            return;
        }

        session.Store<Goal>(GetPreconfiguredGoals());

        await session.SaveChangesAsync();
    }

    public static IEnumerable<Goal> GetPreconfiguredGoals()
    {
        return new List<Goal>
        {
            new Goal
            {
                Id=1,
                Text="Correct in english",
                ProblemId=1,
                TwentyPercent=true,
                Completed=true,
                UserId=UserConstants.UserId
            },
            new Goal
            {
                Id= 2,
                Text="Confidence in english",
                ProblemId=1,
                TwentyPercent=true,
                Completed=true,
                UserId=UserConstants.UserId
            },
              new Goal
            {
                Id= 3,
                Text="Speaking fast",
                ProblemId=1,
                TwentyPercent=true,
                Completed=true,
                UserId=UserConstants.UserId
            },
            new Goal
            {
                Id= 4,
                Text="Fluent in english",
                ProblemId=1,
                TwentyPercent=false,
                Completed=false,
                UserId=UserConstants.UserId
            }
        };
    }
}
