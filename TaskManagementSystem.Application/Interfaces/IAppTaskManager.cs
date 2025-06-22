using TaskManagementSystem.Application.Dtos.AppTask;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Application.Interfaces;

public interface IAppTaskManager
{
    Task<List<AppTaskListDto>> GetAllTasksAsync();
    Task<AppTaskListDto> GetTaskByIdAsync(int id);
    Task CreateTaskAsync(AppTaskCreateDto dto);
    Task UpdateTaskAsync(int id, AppTaskUpdateDto dto);
    Task DeleteTaskAsync(int id);
    Task<List<AppTaskListDto>> GetTasksByUserAsync(string userId);
    Task<List<AppTaskListDto>> GetTasksByCategoryAsync(int categoryId);
    Task<List<AppTaskListDto>> GetTasksByAssignedToEmailAsync(string email);
    Task MarkTaskAsCompletedAsync(int id);
     Task<AppTask> GetEntityByIdAsync(int id);
}
