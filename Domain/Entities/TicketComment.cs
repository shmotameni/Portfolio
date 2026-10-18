using System;

namespace Portfolio.Domain.Entities
{
    public class TicketComment
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public Ticket Ticket { get; set; }
    }
}
