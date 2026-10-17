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

        public async Task<PagedResult<TicketResponse>> GetAllAsync(TicketFilterRequest filter)
        {
            var tickets = _context.Tickets.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();
                tickets = tickets.Where(t => t.Title.Contains(search));
            }

            if (filter.Status.HasValue)
            {
                tickets = tickets.Where(t => t.Status == filter.Status.Value);
            }

            if (filter.Priority.HasValue)
            {
                tickets = tickets.Where(t => t.Priority == filter.Priority.Value);
            }

            var totalCount = await tickets.CountAsync();

            tickets = filter.SortAscending ? tickets.OrderBy(t => t.CreatedAt).ThenBy(t => t.Id)
                                           : tickets.OrderByDescending(t => t.CreatedAt).ThenByDescending(t => t.Id);

            var skip = ((long)filter.PageNumber - 1) * filter.PageSize;

            var ticketsResult = await tickets
                        .Skip((int)Math.Min(skip, int.MaxValue))
                        .Take(filter.PageSize)
                        .Select(t => new TicketResponse
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            Status = t.Status,
                            Priority = t.Priority,
                            CreatedAt = t.CreatedAt
                        })
                        .ToListAsync();

            var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);

            return new PagedResult<TicketResponse>
            {
                Items = ticketsResult,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalPages = totalPages,
                HasPreviousPage = filter.PageNumber > 1 && totalPages > 0,
                HasNextPage = filter.PageNumber < totalPages
            };
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
