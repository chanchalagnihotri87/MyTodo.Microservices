using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Abstractions;
using Tasks.Domain.Models;

namespace Tasks.Domain.Events
{
    public record TodoItemCompletedEvent(TodoItem TodoItem) : IDomainEvent
    {
    }
}
