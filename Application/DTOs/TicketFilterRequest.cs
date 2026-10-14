using System.ComponentModel.DataAnnotations;
using Portfolio.Domain.Enums;

namespace Portfolio.Application.DTOs
{
    public class TicketFilterRequest
    {
        [StringLength(150)]
        public string Search { get; set; }

        [EnumDataType(typeof(TicketStatus))]
        public TicketStatus? Status { get; set; }

        [EnumDataType(typeof(TicketPriority))]
        public TicketPriority? Priority { get; set; }

        // false = ins, true = des
        public bool SortAscending { get; set; } = false;
    }
}