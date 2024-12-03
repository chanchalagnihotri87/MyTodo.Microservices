using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messages.Events
{
    public record ObjectiveCompletionEvent(int ObjectiveId, bool Completed) : IntegrationEvent;
    
}
