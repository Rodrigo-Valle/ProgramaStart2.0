using ProgramaStarter.Application.DTO;

namespace ProgramaStarter.Application.Interfaces;
public interface IAvaliacaoService
{
    Task<IEnumerable<AvaliacaoDTO>> GetAsync(int? starterId);
    Task<AvaliacaoDTO> GetByIdAsync(int? id);
    Task AddAsync(AvaliacaoDTO avaliacaoDto);
    Task UpdateAsync(AvaliacaoDTO avaliacaoDto);
    Task RemoveAsync(int? id);
}
