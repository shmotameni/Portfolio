using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("api/Tickets/{ticketId:int}/activities")]
    public class TicketActivitiesController : ControllerBase
    {
        private readonly ITicketActivityService _activityService;

        public TicketActivitiesController(ITicketActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketActivityResponse>>> GetAll(int ticketId)
        {
            if (!await _activityService.TicketExistsAsync(ticketId))
            {
                return NotFound(new { message = "Ticket not found." });
            }

            var activities = await _activityService.GetByTicketIdAsync(ticketId);

            return Ok(activities);
        }
    }
}
