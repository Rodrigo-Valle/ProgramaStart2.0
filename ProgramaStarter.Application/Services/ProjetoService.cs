using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class ProjetoService : IProjetoService
{
    private IRepository<Projeto> _repository;
    private readonly IMapper _mapper;
    public ProjetoService(IRepository<Projeto> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(ProjetoDTO projetoDto)
    {
        var projetoEntity = _mapper.Map<Projeto>(projetoDto);
        await _repository.CreateAsync(projetoEntity);
    }

    public async Task<ProjetoDTO> GetByIdAsync(int? id)
    {
        var projetoEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProjetoDTO>(projetoEntity);
    }

    public async Task<IEnumerable<ProjetoDTO>> GetAsync()
    {
        var projetoEntities = await _repository.GetListAsync();
        return _mapper.Map<IEnumerable<ProjetoDTO>>(projetoEntities);
    }

    public async Task RemoveAsync(int? id)
    {
        var projetoEntity = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(projetoEntity);
    }

    public async Task UpdateAsync(ProjetoDTO projetocategoryDto)
    {
        var projetoEntity = _mapper.Map<Projeto>(projetocategoryDto);
        await _repository.UpdateAsync(projetoEntity);
    }
}