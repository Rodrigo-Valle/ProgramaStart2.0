using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class StarterService : IStarterService
{
    private IRepository<Starter> _repository;
    private readonly IMapper _mapper;
    public StarterService(IRepository<Starter> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(StarterDTO starterDto)
    {
        var starterEntity = _mapper.Map<Starter>(starterDto);
        await _repository.CreateAsync(starterEntity);
    }

    public async Task<StarterDTO> GetByIdAsync(int? id)
    {
        var starterEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<StarterDTO>(starterEntity);
    }

    public async Task<IEnumerable<StarterDTO>> GetAsync()
    {
        var starterEntities = await _repository.GetListAsync();
        return _mapper.Map<IEnumerable<StarterDTO>>(starterEntities);
    }

    public async Task RemoveAsync(int? id)
    {
        var starterEntity = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(starterEntity);
    }

    public async Task UpdateAsync(StarterDTO startercategoryDto)
    {
        var starterEntity = _mapper.Map<Starter>(startercategoryDto);
        await _repository.UpdateAsync(starterEntity);
    }
}