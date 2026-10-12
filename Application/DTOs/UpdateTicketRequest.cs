using Portfolio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.DTOs
{
    public class UpdateTicketRequest
    {
        [Required(ErrorMessage = "Ticket title is required.")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ticket description is required.")]
        [StringLength(2000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ticket status is required.")]
        [EnumDataType(typeof(TicketStatus), ErrorMessage = "Invalid ticket status.")]
        public TicketStatus? Status { get; set; }

        [Required(ErrorMessage = "Ticket priority is required.")]
        [EnumDataType(typeof(TicketPriority), ErrorMessage = "Invalid ticket priority.")]
        public TicketPriority? Priority { get; set; }
    }
}
