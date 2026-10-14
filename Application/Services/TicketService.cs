using Microsoft.EntityFrameworkCore;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;
using Portfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Priority = request.Priority.Value,
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

        public async Task<TicketResponse> UpdateAsync(int id, UpdateTicketRequest request)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return null;
            }

            ticket.Title = request.Title;
            ticket.Description = request.Description;
            ticket.Status = request.Status.Value;
            ticket.Priority = request.Priority.Value;
            ticket.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                Priority = ticket.Priority,
                CreatedAt = ticket.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return false;
            }

            _context.Tickets.Remove(ticket);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<TicketResponse>> GetAllAsync(TicketFilterRequest filter)
        {
            var tickets = _context.Tickets.AsNoTracking().AsQueryable();
           
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();
                tickets = tickets.Where(t => t.Title.Contains(search));
            }

            if (filter.Priority.HasValue)
            {
                tickets = tickets.Where(t => t.Priority == filter.Priority.Value);
            }

            tickets = filter.SortAscending ? tickets.OrderBy(t => t.CreatedAt).ThenBy(t => t.Id)
                                           : tickets.OrderByDescending(t => t.CreatedAt).ThenByDescending(t => t.Id);

            return await tickets.Select(ticket => new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                Priority = ticket.Priority,
                CreatedAt = ticket.CreatedAt
            }).ToListAsync();
        }

        public async Task<TicketResponse> GetByIdAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return null;
            }

            return new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                Priority = ticket.Priority,
                CreatedAt = ticket.CreatedAt
            };
        }
    }
}
