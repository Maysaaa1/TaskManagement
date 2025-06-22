using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;
using TaskManagementSystem.Infrastructure.Data;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class AppTaskRepository : Repository<AppTask>, IAppTaskRepository
    {
        private readonly TMSDbContext _context;

        public AppTaskRepository(TMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AppTask>> GetTasksByUserAsync(string userId)
        {
            return await _context.AppTasks
                .Where(t => t.AssignedTo == userId)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .ToListAsync();
        }

        public async Task<List<AppTask>> GetTasksByCategoryAsync(int categoryId)
        {
            return await _context.AppTasks
                .Where(t => t.CategoryId == categoryId)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .ToListAsync();
        }

       
        public async Task<List<AppTask>> GetAllWithDetailsAsync()
        {
            return await _context.AppTasks
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .ToListAsync();
        }
    }
}
