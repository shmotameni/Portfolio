using Portfolio.Domain.Enums;

namespace Portfolio.Application.DTOs
{
    public class UpdateTicketRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TicketStatus Status { get; set; }

        public TicketPriority Priority { get; set; }
    }
}
