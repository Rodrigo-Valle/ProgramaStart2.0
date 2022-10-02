using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class AvaliacaoRepository : IAvaliacaoRepository
{
    private ApplicationDbContext _context;
    public AvaliacaoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Avaliacao> CreateAsync(Avaliacao avaliacao)
    {
        _context.Add(avaliacao);
        await _context.SaveChangesAsync();
        return avaliacao;
    }

    public async Task<Avaliacao> GetByIdAsync(int? id)
    {
        var avaliacao = await _context.Avaliacoes.Include(p => p.Projeto)
                                                 .Include(m => m.Projeto.Modulo)
                                                 .Include(s => s.Starter)
                                                 .FirstOrDefaultAsync(a => a.Id == id);
        return avaliacao;
    }

    public async Task<IEnumerable<Avaliacao>> GetListAsync(int? starterId)
    {
        var avaliacaos = await _context.Avaliacoes
                                       .Include(p => p.Projeto)
                                       .Include(m => m.Projeto.Modulo)
                                       .Include(s => s.Starter)
                                       .Where(s => s.Starter.Id == starterId)
                                       .ToListAsync();
        return avaliacaos;
    }

    public async Task<Avaliacao> RemoveAsync(Avaliacao avaliacao)
    {
        _context.Remove(avaliacao);
        await _context.SaveChangesAsync();
        return avaliacao;
    }

    public async Task<Avaliacao> UpdateAsync(Avaliacao avaliacao)
    {
        _context.Update(avaliacao);
        await _context.SaveChangesAsync();
        return avaliacao;
    }
}
