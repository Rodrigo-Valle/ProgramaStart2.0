using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface ITecnologiaService
{
    Task<IEnumerable<TecnologiaDTO>> GetAsync();
    Task<TecnologiaDTO> GetByIdAsync(int? id);
    Task AddAsync(TecnologiaDTO tecnologiaDto);
    Task UpdateAsync(TecnologiaDTO tecnologiaDto);
    Task RemoveAsync(int? id);
}
