using Portfolio.Application.DTOs;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponse> CreateAsync(CreateTicketRequest request);
    }
}
