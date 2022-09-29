

using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface IProgramaStartService
{
    Task<IEnumerable<ProgramaStartDTO>> GetAsync();
    Task<ProgramaStartDTO> GetByIdAsync(int? id);
    Task AddAsync(ProgramaStartDTO programaStartDto);
    Task UpdateAsync(ProgramaStartDTO programaStartcategoryDto);
    Task RemoveAsync(int? id);
}