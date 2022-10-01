using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class ProgramaRepository : IRepository<Programa>
{
    private ApplicationDbContext _context;
    public ProgramaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    public async Task<Programa> CreateAsync(Programa programa)
    {
        _context.Add(programa);
        await _context.SaveChangesAsync();
        return programa;
    }

    public async Task<Programa> GetByIdAsync(int? id)
    {
        var programa = await _context.Programas.FindAsync(id);
        return programa;
    }

    public async Task<IEnumerable<Programa>> GetListAsync()
    {
        var programas = await _context.Programas.ToListAsync();
        return programas;
    }

    public async Task<Programa> RemoveAsync(Programa programa)
    {
        _context.Remove(programa);
        await _context.SaveChangesAsync();
        return programa;
    }

    public async Task<Programa> UpdateAsync(Programa programa)
    {
        _context.Update(programa);
        await _context.SaveChangesAsync();
        return programa;
    }
}