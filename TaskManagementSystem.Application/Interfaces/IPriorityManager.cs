using TaskManagementSystem.Application.Dtos.Priority;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IPriorityManager
    {
        Task<Priority> GetEntityByIdAsync(int id);
        Task<List<PriorityListDto>> GetAllPrioritiesAsync();
        Task<PriorityListDto> GetPriorityByIdAsync(int id);
        Task CreateAsync(PriorityCreateDto dto);
        Task UpdateAsync(int id, PriorityUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
