using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class AvaliacaoService : IAvaliacaoService
{
    private IAvaliacaoRepository _repository;
    private readonly IMapper _mapper;
    public AvaliacaoService(IAvaliacaoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(AvaliacaoDTO avaliacaoDto)
    {
        var avaliacaoEntity = _mapper.Map<Avaliacao>(avaliacaoDto);
        await _repository.CreateAsync(avaliacaoEntity);
    }

    public async Task<AvaliacaoDTO> GetByIdAsync(int? id)
    {
        var avaliacaoEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<AvaliacaoDTO>(avaliacaoEntity);
    }

    public async Task<IEnumerable<AvaliacaoDTO>> GetAsync(int? starterId)
    {
        var avaliacaoEntities = await _repository.GetListAsync(starterId);
        return _mapper.Map<IEnumerable<AvaliacaoDTO>>(avaliacaoEntities);
    }

    public async Task RemoveAsync(int? id)
    {
        var avaliacaoEntity = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(avaliacaoEntity);
    }

    public async Task UpdateAsync(AvaliacaoDTO avaliacaocategoryDto)
    {
        var avaliacaoEntity = _mapper.Map<Avaliacao>(avaliacaocategoryDto);
        await _repository.UpdateAsync(avaliacaoEntity);
    }
}