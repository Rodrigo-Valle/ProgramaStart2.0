using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class StarterRepository : IRepository<Starter>
{
    private ApplicationDbContext _context;
    public StarterRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Starter> CreateAsync(Starter starter)
    {
        _context.Add(starter);
        await _context.SaveChangesAsync();
        return starter;
    }

    public async Task<Starter> GetByIdAsync(int? id)
    {
        var starter = await _context.Starters.FindAsync(id);
        return starter;
    }

    public async Task<IEnumerable<Starter>> GetListAsync()
    {
        var starters = await _context.Starters.ToListAsync();
        return starters;
    }

    public async Task<Starter> RemoveAsync(Starter starter)
    {
        _context.Remove(starter);
        await _context.SaveChangesAsync();
        return starter;
    }

    public async Task<Starter> UpdateAsync(Starter starter)
    {
        _context.Update(starter);
        await _context.SaveChangesAsync();
        return starter;
    }
}
