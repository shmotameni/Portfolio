using Portfolio.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ITicketCommentService
    {
        Task<TicketCommentResponse> CreateAsync(int ticketId, CreateTicketCommentRequest request);

        Task<List<TicketCommentResponse>> GetByTicketIdAsync(int ticketId);

        Task<bool> TicketExistsAsync(int ticketId);
    }
}
