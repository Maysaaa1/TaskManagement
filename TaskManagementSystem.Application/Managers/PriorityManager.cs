using AutoMapper;
using TaskManagementSystem.Application.Dtos.Priority;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Application.Managers
{
    public class PriorityManager : IPriorityManager
    {
        private readonly IPriorityRepository _repo;
        private readonly IMapper _mapper;

        public PriorityManager(IPriorityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PriorityListDto>> GetAllPrioritiesAsync()
        {
            var priorities = await _repo.GetAllAsync();
            return _mapper.Map<List<PriorityListDto>>(priorities);
        }

        public async Task<PriorityListDto> GetPriorityByIdAsync(int id)
        {
            var priority = await _repo.GetByIdAsync(id);
            if (priority == null)
                throw new NotFoundException($"Priority with ID {id} not found");

            return _mapper.Map<PriorityListDto>(priority);
        }

        public async Task<Priority> GetEntityByIdAsync(int id)
        {
            var priority = await _repo.GetByIdAsync(id); 
            if (priority == null)
                throw new NotFoundException($"Priority with ID {id} not found");

            return priority;
        }

        public async Task CreateAsync(PriorityCreateDto dto)
        {
            var newPriority = _mapper.Map<Priority>(dto);
            await _repo.AddAsync(newPriority);
        }

        public async Task UpdateAsync(int id, PriorityUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException("Priority not found");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var priority = await _repo.GetByIdAsync(id);
            if (priority == null)
                throw new NotFoundException($"Priority with ID {id} not found");

            await _repo.DeleteAsync(id);
        }
    }
}
