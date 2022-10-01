using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface IStarterService
{
    Task<IEnumerable<StarterDTO>> GetAsync();
    Task<StarterDTO> GetByIdAsync(int? id);
    Task AddAsync(StarterDTO starterDto);
    Task UpdateAsync(StarterDTO starterDto);
    Task RemoveAsync(int? id);
}
