using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Domain.Enums
{
    public enum TicketActivityType
    {
        Created = 0,
        StatusChanged = 1,
        PriorityChanged = 2,
        CommentAdded = 3
    }
}
