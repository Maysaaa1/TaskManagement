using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;
namespace TaskManagementSystem.Core.Interfaces
{


    public interface IAppTaskRepository : IRepository<AppTask>
    {
        Task<List<AppTask>> GetTasksByUserAsync(string userId);
        Task<List<AppTask>> GetTasksByCategoryAsync(int categoryId);

        Task<List<AppTask>> GetAllWithDetailsAsync();

    }

}
