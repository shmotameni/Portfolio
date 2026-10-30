using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs
{
    public class TicketActivityResponse
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public TicketActivityType Type { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
