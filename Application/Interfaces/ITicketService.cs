using Portfolio.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponse> CreateAsync(CreateTicketRequest request);

        Task<TicketResponse> UpdateAsync(int id, UpdateTicketRequest request);

        Task<bool> DeleteAsync(int id);

        Task<PagedResult<TicketResponse>> GetAllAsync(TicketFilterRequest filter);

        Task<TicketResponse> GetByIdAsync(int id);
    }
}
