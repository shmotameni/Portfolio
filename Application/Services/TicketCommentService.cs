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
    public class TicketCommentService : ITicketCommentService
    {
        private readonly PortfolioDbContext _context;

        public TicketCommentService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TicketExistsAsync(int ticketId)
        {
            return await _context.Tickets.AnyAsync(t => t.Id == ticketId);
        }

        public async Task<TicketCommentResponse> CreateAsync(int ticketId, CreateTicketCommentRequest request)
        {
            if (!await TicketExistsAsync(ticketId))
            {
                return null;
            }

            var comment = new TicketComment
            {
                TicketId = ticketId,
                AuthorName = request.AuthorName,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            _context.TicketComments.Add(comment);

            _context.TicketActivities.Add(new TicketActivity
            {
                TicketId = ticketId,
                Type = TicketActivityType.CommentAdded,
                Description = "A comment was added.",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();

            return new TicketCommentResponse
            {
                Id = comment.Id,
                TicketId = comment.TicketId,
                AuthorName = comment.AuthorName,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            };
        }

        public async Task<List<TicketCommentResponse>> GetByTicketIdAsync(
            int ticketId)
        {
            return await _context.TicketComments
                .AsNoTracking()
                .Where(c => c.TicketId == ticketId)
                .OrderBy(c => c.CreatedAt)
                .ThenBy(c => c.Id)
                .Select(c => new TicketCommentResponse
                {
                    Id = c.Id,
                    TicketId = c.TicketId,
                    AuthorName = c.AuthorName,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();
        }
    }
}
