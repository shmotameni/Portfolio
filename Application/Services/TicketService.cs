using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;
using Portfolio.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly PortfolioDbContext _context;

        public TicketService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<TicketResponse> CreateAsync(CreateTicketRequest request)
        {
            var ticket = new Ticket
            {
                Id = 1,
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Status = TicketStatus.Open,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tickets.Add(ticket);

            await _context.SaveChangesAsync();

            return new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Priority = ticket.Priority,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt
            };            
        }
    }
}
