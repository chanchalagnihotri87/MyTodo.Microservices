using BuildingBlocks.Messages.Events;
using MassTransit;
using Objectives.API.Domain;
using System.Threading;

namespace Objectives.API.Objectives.EventHandlers.Integration
{
    public class ObjectiveCompletionEventHandler(ObjectiveDbContext dbContext) : IConsumer<ObjectiveCompletionEvent>
    {
        public async Task Consume(ConsumeContext<ObjectiveCompletionEvent> context)
        {
            var objective = await dbContext.Objectives.FindAsync(context.Message.ObjectiveId);

            if (objective.Completed == context.Message.Completed)
            {
                return;
            }

            objective.Completed = context.Message.Completed;

            dbContext.Objectives.Update(objective);

            await dbContext.SaveChangesAsync();
        }
    }
}
