using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.DTOs
{
    public class CreateTicketCommentRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 2)]
        public string Content { get; set; }
    }
}
