using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class TicketActivity
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public TicketActivityType Type { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public Ticket Ticket { get; set; }
    }
}
