using BuildingBlocks.Messages.Events;
using MassTransit;
using Objectives.API.Domain;
using System.Threading;

namespace Objectives.API.Objectives.EventHandlers.Integration
{
    public class ObjectiveCompletionEventHandler(IDocumentSession session) : IConsumer<ObjectiveCompletionEvent>
    {
        public async Task Consume(ConsumeContext<ObjectiveCompletionEvent> context)
        {
            var objective = await session.LoadAsync<Objective>(context.Message.ObjectiveId);

            if (objective.Completed == context.Message.Completed)
            {
                return;
            }

            objective.Completed = context.Message.Completed;

            session.Update(objective);

            await session.SaveChangesAsync();
        }
    }
}
