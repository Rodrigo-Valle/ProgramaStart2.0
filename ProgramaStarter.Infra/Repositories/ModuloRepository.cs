using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class ModuloRepository : IRepository<Modulo>
{
    private ApplicationDbContext _context;
    public ModuloRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Modulo> CreateAsync(Modulo modulo)
    {
        _context.Add(modulo);
        await _context.SaveChangesAsync();
        return modulo;
    }

    public async Task<Modulo> GetByIdAsync(int? id)
    {
        var modulo = await _context.Modulos.FindAsync(id);
        return modulo;
    }

    public async Task<IEnumerable<Modulo>> GetListAsync()
    {
        var modulos = await _context.Modulos.ToListAsync();
        return modulos;
    }

    public async Task<Modulo> RemoveAsync(Modulo modulo)
    {
        _context.Remove(modulo);
        await _context.SaveChangesAsync();
        return modulo;
    }

    public async Task<Modulo> UpdateAsync(Modulo modulo)
    {
        _context.Update(modulo);
        await _context.SaveChangesAsync();
        return modulo;
    }
}
