using System;

namespace Portfolio.Application.DTOs
{
    public class TicketCommentResponse
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
