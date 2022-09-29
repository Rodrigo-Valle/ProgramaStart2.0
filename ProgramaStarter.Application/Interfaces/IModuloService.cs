using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface IModuloService
{
    Task<IEnumerable<ModuloDTO>> GetAsync();
    Task<ModuloDTO> GetByIdAsync(int? id);
    Task AddAsync(ModuloDTO moduloDto);
    Task UpdateAsync(ModuloDTO moduloDto);
    Task RemoveAsync(int? id);
}
