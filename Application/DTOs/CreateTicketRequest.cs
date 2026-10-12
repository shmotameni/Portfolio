using System.ComponentModel.DataAnnotations;
using Portfolio.Domain.Enums;

namespace Portfolio.Application.DTOs
{
    public class CreateTicketRequest
    {
        [Required(ErrorMessage = "Ticket title is required.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Title must contain between 3 and 150 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ticket description is required.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Description must contain between 10 and 2000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ticket priority is required.")]
        [EnumDataType(typeof(TicketPriority), ErrorMessage = "Invalid ticket priority.")]
        public TicketPriority? Priority { get; set; }
    }
}
