using Microsoft.EntityFrameworkCore;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class TicketActivityService : ITicketActivityService
    {
        private readonly PortfolioDbContext _context;

        public TicketActivityService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TicketExistsAsync(int ticketId)
        {
            return await _context.Tickets.AnyAsync(t => t.Id == ticketId);
        }

        public async Task<List<TicketActivityResponse>> GetByTicketIdAsync(int ticketId)
        {
            return await _context.TicketActivities
                .AsNoTracking()
                .Where(a => a.TicketId == ticketId)
                .OrderBy(a => a.CreatedAt)
                .ThenBy(a => a.Id)
                .Select(a => new TicketActivityResponse
                {
                    Id = a.Id,
                    TicketId = a.TicketId,
                    Type = a.Type,
                    Description = a.Description,
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();
        }
    }
}
