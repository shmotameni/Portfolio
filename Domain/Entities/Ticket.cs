using System;
using Portfolio.Domain.Enums;

namespace Portfolio.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TicketStatus Status { get; set; }

        public TicketPriority Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
