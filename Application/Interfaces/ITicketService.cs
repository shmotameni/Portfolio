using Portfolio.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponse> CreateAsync(CreateTicketRequest request);

        Task<List<TicketResponse>> GetAllAsync();

        Task<TicketResponse> GetByIdAsync(int id);
    }
}
