using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class TicketService : ITicketService
    {
        public Task<TicketResponse> CreateAsync(CreateTicketRequest request)
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

            var response = new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Priority = ticket.Priority,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt
            };

            return Task.FromResult(response);
        }
    }
}
