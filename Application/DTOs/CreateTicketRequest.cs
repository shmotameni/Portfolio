using System;
using Portfolio.Domain.Enums;

namespace Portfolio.Application.DTOs
{
    public class CreateTicketRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TicketPriority Priority { get; set; }
    }
}
