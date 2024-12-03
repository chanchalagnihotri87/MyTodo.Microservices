using BuildingBlocks.Messages.Events;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Data;
using Tasks.Domain.Events;

namespace Tasks.Application.Todos.EventHandlers.Domain
{
    public class TodoItemCompletedEventHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint) : INotificationHandler<TodoItemCompletedEvent>
    {
        public async Task Handle(TodoItemCompletedEvent domainEvent, CancellationToken cancellationToken)
        {
            var task = await dbContext.Tasks.FindAsync(domainEvent.TodoItem.TaskId);

            bool taskUpdated = false;

            if (task.Completed == domainEvent.TodoItem.Completed)
            {
                return;
            }

            if (domainEvent.TodoItem.Completed)
            {
                if (!dbContext.TodoItems.Any(x => x.TaskId == task.Id && x.Id != domainEvent.TodoItem.Id && !x.Completed))
                {
                    task.Completed = true;
                    taskUpdated = true;
                }
            }

            if (!domainEvent.TodoItem.Completed)
            {
                if (task.Completed)
                {
                    task.Completed = false;
                    taskUpdated = true;
                }
            }

            if ((taskUpdated))
            {
                dbContext.Tasks.Update(task);
                await dbContext.SaveChangesAsync(cancellationToken);


                await publishEndpoint.Publish(new ObjectiveCompletionEvent(task.ObjectiveId, task.Completed));
            }

        }
    }
}
