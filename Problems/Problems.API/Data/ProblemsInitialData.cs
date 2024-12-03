using BuildingBlocks.Helper;
using Marten.Schema;
using Problems.API.Domain;

namespace Problems.API.Data
{
    public class ProblemsInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Problem>().AnyAsync())
            {
                return;
            }

            session.Store<Problem>(GetPreconfiguredProblems());

            await session.SaveChangesAsync();
        }

        public static IEnumerable<Problem> GetPreconfiguredProblems()
        {

            return new List<Problem>
            {
                new Problem
                {
                   Id= 1,
                   Text="Not able to speak in english",
                   LifeAreaId= 1,
                   Completed= true,
                   TwentyPercent= true,
                   Index= 1,
                   User_Id= UserConstants.UserId
                },
                new Problem
                {
                   Id= 2,
                   Text="Lack of sales man skill",
                   LifeAreaId= 1,
                   Completed= true,
                   TwentyPercent= true,
                   Index=2,
                   User_Id= UserConstants.UserId
                },
                new Problem
                {
                   Id= 3,
                   Text="Build product from scratch",
                   LifeAreaId= 1,
                   Completed= true,
                   TwentyPercent= true,
                   Index=3,
                   User_Id= UserConstants.UserId
                },
                new Problem
                {
                   Id= 4,
                   Text="Business mindset",
                   LifeAreaId= 1,
                   Completed= true,
                   TwentyPercent= true,
                   Index=1,
                   User_Id= UserConstants.UserId
                }
            };

        }
    }
}
