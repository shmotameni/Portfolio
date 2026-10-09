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

        [HttpGet]
        public async Task<ActionResult<List<TicketResponse>>> GetAll()
        {
            var tickets = await _ticketService.GetAllAsync();

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
