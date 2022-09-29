
using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class ProgramaStartService : IProgramaStartService
{
    private IRepository<ProgramaStart> _repository;
    private readonly IMapper _mapper;
    public ProgramaStartService(IRepository<ProgramaStart> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(ProgramaStartDTO programaStartDto)
    {
        var programaStartEntity = _mapper.Map<ProgramaStart>(programaStartDto);
        await _repository.CreateAsync(programaStartEntity);
    }

    public async Task<ProgramaStartDTO> GetByIdAsync(int? id)
    {
        var programaStartEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProgramaStartDTO>(programaStartEntity);
    }

    public async Task<IEnumerable<ProgramaStartDTO>> GetAsync()
    {
        var programaStartEntities = await _repository.GetListAsync();
        return _mapper.Map<IEnumerable<ProgramaStartDTO>>(programaStartEntities);
    }

    public async Task RemoveAsync(int? id)
    {
        var programaStartEntity = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(programaStartEntity);
    }

    public async Task UpdateAsync(ProgramaStartDTO programaStartcategoryDto)
    {
        var programaStartEntity = _mapper.Map<ProgramaStart>(programaStartcategoryDto);
        await _repository.UpdateAsync(programaStartEntity);
    }
}