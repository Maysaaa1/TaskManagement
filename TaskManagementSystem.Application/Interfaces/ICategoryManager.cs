using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Dtos.Category;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ICategoryManager
    {
        Task<Category> GetEntityByIdAsync(int id);

        Task<List<CategoryListDto>> GetAllCategoriesAsync();
        Task <CategoryListDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CategoryUpdateDto dto);
       Task<List<CategoryListDto>> GetAllAsync();
     
    }
}
