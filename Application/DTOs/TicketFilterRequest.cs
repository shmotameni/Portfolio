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

        [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than zero.")]
        public int PageNumber { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int PageSize { get; set; } = 10;
    }
}