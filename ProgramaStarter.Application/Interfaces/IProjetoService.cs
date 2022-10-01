using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface IProjetoService
{
    Task<IEnumerable<ProjetoDTO>> GetAsync();
    Task<ProjetoDTO> GetByIdAsync(int? id);
    Task AddAsync(ProjetoDTO projetoDto);
    Task UpdateAsync(ProjetoDTO projetoDto);
    Task RemoveAsync(int? id);
}
