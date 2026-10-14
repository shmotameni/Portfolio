using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        ////private readonly ILogger<TicketsController> _logger;

        ////public TicketsController(ILogger<TicketsController> logger)
        ////{
        ////    _logger = logger;
        ////}

        [HttpPost]
        public async Task<ActionResult<TicketResponse>> Create(CreateTicketRequest request)
        {
            var result = await _ticketService.CreateAsync(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TicketResponse>> Update(int id, UpdateTicketRequest request)
        {
            var result = await _ticketService.UpdateAsync(id, request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ticketService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketResponse>>> GetAll([FromQuery] TicketFilterRequest filter)
        {
            var tickets = await _ticketService.GetAllAsync(filter);

            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketResponse>> GetById(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }
    }
}
