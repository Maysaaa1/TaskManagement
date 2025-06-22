using AutoMapper;
using TaskManagementSystem.Application.Dtos.AppTask;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Application.Managers
{
    public class AppTaskManager : IAppTaskManager
    {
        private readonly IAppTaskRepository _repo;
        private readonly IMapper _mapper;

        public AppTaskManager(IAppTaskRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        
        public async Task<List<AppTaskListDto>> GetAllTasksAsync()
        {
            var tasks = await _repo.GetAllWithDetailsAsync();
            return _mapper.Map<List<AppTaskListDto>>(tasks);
        }

       
        public async Task<AppTaskListDto> GetTaskByIdAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                throw new NotFoundException($"Task with ID {id} not found");

            return _mapper.Map<AppTaskListDto>(task);
        }

       
        public async Task<AppTask> GetEntityByIdAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                throw new NotFoundException($"Task with ID {id} not found");

            return task;
        }

        
        public async Task CreateTaskAsync(AppTaskCreateDto dto)
        {
            var task = _mapper.Map<AppTask>(dto);
            task.CreatedAt = DateTime.Now;
            task.IsCompleted = false;
            await _repo.AddAsync(task);
        }

     
        public async Task UpdateTaskAsync(int id, AppTaskUpdateDto dto)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                throw new NotFoundException($"Task with ID {id} not found");

            _mapper.Map(dto, task);
            await _repo.UpdateAsync(task);

        }

        
        public async Task DeleteTaskAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                throw new NotFoundException($"Task with ID {id} not found");

            await _repo.DeleteAsync(id);
        }

       
        public async Task MarkTaskAsCompletedAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                throw new NotFoundException($"Task with ID {id} not found");

            task.IsCompleted = true;
            await _repo.UpdateAsync(task);
        }

      
        public async Task<List<AppTaskListDto>> GetTasksByAssignedToEmailAsync(string email)
        {
            var all = await _repo.GetAllWithDetailsAsync();
            var filtered = all.Where(t => t.AssignedTo == email).ToList();
            return _mapper.Map<List<AppTaskListDto>>(filtered);
        }

       
        public async Task<List<AppTaskListDto>> GetTasksByUserAsync(string userId)
        {
            var tasks = await _repo.GetTasksByUserAsync(userId);
            return _mapper.Map<List<AppTaskListDto>>(tasks);
        }

        
        public async Task<List<AppTaskListDto>> GetTasksByCategoryAsync(int categoryId)
        {
            var tasks = await _repo.GetTasksByCategoryAsync(categoryId);
            return _mapper.Map<List<AppTaskListDto>>(tasks);
        }
    }
}
