using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;
using TaskManagementSystem.Infrastructure.Data;

public class PriorityRepository : Repository<Priority>, IPriorityRepository
{
    private readonly TMSDbContext _context;

    public PriorityRepository(TMSDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Priority?> GetByIdAsync(int id)
    {
        return await _context.Priorities.FindAsync(id);
    }

    public async Task<Priority?> GetByNameAsync(string name)
    {
        return await _context.Priorities.FirstOrDefaultAsync(p => p.Name == name);
    }
}
