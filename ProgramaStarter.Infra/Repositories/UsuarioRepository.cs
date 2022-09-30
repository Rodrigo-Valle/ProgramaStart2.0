using ProgramaStarter.Domain.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProgramaStarter.Infra.Data.Repositories;

public class UsuarioRepository : IRepository<Usuario>
{
    private ApplicationDbContext _context;
    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        _context.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> GetByIdAsync(int? id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        return usuario;
    }

    public async Task<IEnumerable<Usuario>> GetListAsync()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        return usuarios;
    }

    public async Task<Usuario> RemoveAsync(Usuario usuario)
    {
        _context.Remove(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        _context.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }
}
