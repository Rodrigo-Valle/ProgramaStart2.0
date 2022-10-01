
using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class ProgramaService : IProgramaService
{
    private IRepository<Programa> _repository;
    private readonly IMapper _mapper;
    public ProgramaService(IRepository<Programa> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(ProgramaDTO programaDto)
    {
        var programaEntity = _mapper.Map<Programa>(programaDto);
        await _repository.CreateAsync(programaEntity);
    }

    public async Task<ProgramaDTO> GetByIdAsync(int? id)
    {
        var programaEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProgramaDTO>(programaEntity);
    }

    public async Task<IEnumerable<ProgramaDTO>> GetAsync()
    {
        var programaEntities = await _repository.GetListAsync();
        return _mapper.Map<IEnumerable<ProgramaDTO>>(programaEntities);
    }

    public async Task RemoveAsync(int? id)
    {
        var programaEntity = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(programaEntity);
    }

    public async Task UpdateAsync(ProgramaDTO programaDto)
    {
        var programaEntity = _mapper.Map<Programa>(programaDto);
        await _repository.UpdateAsync(programaEntity);
    }
}