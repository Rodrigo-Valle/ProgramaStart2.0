using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAsync();
    Task<UsuarioDTO> GetByIdAsync(int? id);
    Task AddAsync(UsuarioDTO usuarioDto);
    Task UpdateAsync(UsuarioDTO usuarioDto);
    Task RemoveAsync(int? id);
}
