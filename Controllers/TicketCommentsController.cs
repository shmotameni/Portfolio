using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("api/Tickets/{ticketId:int}/comments")]
    public class TicketCommentsController : ControllerBase
    {
        private readonly ITicketCommentService _commentService;

        public TicketCommentsController(ITicketCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult<TicketCommentResponse>> Create(int ticketId, [FromBody] CreateTicketCommentRequest request)
        {
            var result = await _commentService.CreateAsync(ticketId, request);

            if (result == null)
            {
                return NotFound(new { message = "Ticket not found." });
            }

            return CreatedAtAction(nameof(GetAll), new { ticketId = ticketId }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketCommentResponse>>> GetAll(int ticketId)
        {
            if (!await _commentService.TicketExistsAsync(ticketId))
            {
                return NotFound(new { message = "Ticket not found." });
            }

            var comments = await _commentService.GetByTicketIdAsync(ticketId);

            return Ok(comments);
        }
    }
}
