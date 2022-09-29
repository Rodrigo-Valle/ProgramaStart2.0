using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class ProgramaStartRepository : IRepository<ProgramaStart>
{
    private ApplicationDbContext _context;
    public ProgramaStartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    public async Task<ProgramaStart> CreateAsync(ProgramaStart programa)
    {
        _context.Add(programa);
        await _context.SaveChangesAsync();
        return programa;
    }

    public async Task<ProgramaStart> GetByIdAsync(int? id)
    {
        var programa = await _context.ProgramasStarter.FindAsync(id);
        return programa;
    }

    public async Task<IEnumerable<ProgramaStart>> GetListAsync()
    {
        var programas = await _context.ProgramasStarter.ToListAsync();
        return programas;
    }

    public async Task<ProgramaStart> RemoveAsync(ProgramaStart programa)
    {
        _context.Remove(programa);
        await _context.SaveChangesAsync();
        return programa;
    }

    public async Task<ProgramaStart> UpdateAsync(ProgramaStart programa)
    {
        _context.Update(programa);
        await _context.SaveChangesAsync();
        return programa;
    }
}