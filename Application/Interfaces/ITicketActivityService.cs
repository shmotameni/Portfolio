using Portfolio.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ITicketActivityService
    {
        Task<bool> TicketExistsAsync(int ticketId);

        Task<List<TicketActivityResponse>> GetByTicketIdAsync(int ticketId);
    }
}
