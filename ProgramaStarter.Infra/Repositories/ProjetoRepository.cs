using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class ProjetoRepository : IRepository<Projeto>
{
    private ApplicationDbContext _context;
    public ProjetoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Projeto> CreateAsync(Projeto projeto)
    {
        _context.Add(projeto);
        await _context.SaveChangesAsync();
        return projeto;
    }

    public async Task<Projeto> GetByIdAsync(int? id)
    {
        var projeto = await _context.Projetos.Include(m => m.Modulo).SingleOrDefaultAsync(p => p.Id == id);
        return projeto;
    }

    public async Task<IEnumerable<Projeto>> GetListAsync()
    {
        var projetos = await _context.Projetos.Include(m => m.Modulo).ToListAsync();
        return projetos;
    }

    public async Task<Projeto> RemoveAsync(Projeto projeto)
    {
        _context.Remove(projeto);
        await _context.SaveChangesAsync();
        return projeto;
    }

    public async Task<Projeto> UpdateAsync(Projeto projeto)
    {
        _context.Update(projeto);
        await _context.SaveChangesAsync();
        return projeto;
    }
}
