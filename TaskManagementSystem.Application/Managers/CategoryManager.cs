using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dtos.Category;
using TaskManagementSystem.Application.Dtos.Priority;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Application.Managers
{
   public class CategoryManager : ICategoryManager

    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> GetAllCategoriesAsync()
        {
            var categories = await _repo.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }
        public async Task<CategoryListDto> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
                throw new NotFoundException($"Category with ID {id} not found");
            return _mapper.Map<CategoryListDto>(category);
        }
        public async Task CreateAsync(CategoryCreateDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _repo.AddAsync(category);
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
                throw new NotFoundException($"Category with ID {id} not found");
            await _repo.DeleteAsync(id);
        }
        public async Task UpdateAsync(int id, CategoryUpdateDto dto)
        {
            var existingCategory = await _repo.GetByIdAsync(id);
            if (existingCategory == null)
                throw new NotFoundException("Category  not found");

          
            _mapper.Map(dto, existingCategory);

            await _repo.UpdateAsync(existingCategory );
        }
        public async Task<List<CategoryListDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }
        public async Task<Category> GetEntityByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
                throw new NotFoundException($"Category with ID {id} not found");

            return category;
        }


    }
}
