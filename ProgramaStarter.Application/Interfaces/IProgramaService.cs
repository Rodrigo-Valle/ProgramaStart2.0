

using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface IProgramaService
{
    Task<IEnumerable<ProgramaDTO>> GetAsync();
    Task<ProgramaDTO> GetByIdAsync(int? id);
    Task AddAsync(ProgramaDTO programaDto);
    Task UpdateAsync(ProgramaDTO programaDto);
    Task RemoveAsync(int? id);
}