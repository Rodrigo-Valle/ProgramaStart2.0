using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class TecnologiaRepository : IRepository<Tecnologia>
{
    private ApplicationDbContext _context;
    public TecnologiaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Tecnologia> CreateAsync(Tecnologia tecnologia)
    {
        _context.Add(tecnologia);
        await _context.SaveChangesAsync();
        return tecnologia;
    }

    public async Task<Tecnologia> GetByIdAsync(int? id)
    {
        var tecnologia = await _context.Tecnologias.FindAsync(id);
        return tecnologia;
    }

    public async Task<IEnumerable<Tecnologia>> GetListAsync()
    {
        var tecnologias = await _context.Tecnologias.ToListAsync();
        return tecnologias;
    }

    public async Task<Tecnologia> RemoveAsync(Tecnologia tecnologia)
    {
        _context.Remove(tecnologia);
        await _context.SaveChangesAsync();
        return tecnologia;
    }

    public async Task<Tecnologia> UpdateAsync(Tecnologia tecnologia)
    {
        _context.Update(tecnologia);
        await _context.SaveChangesAsync();
        return tecnologia;
    }
}
