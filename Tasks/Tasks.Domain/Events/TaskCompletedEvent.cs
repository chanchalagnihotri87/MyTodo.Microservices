using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Abstractions;

namespace Tasks.Domain.Events
{
    public  record TaskCompletedEvent(Domain.Models.Task Task): IDomainEvent
    {
    }
}
