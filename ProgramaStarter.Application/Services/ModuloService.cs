using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class ModuloService : IModuloService
{
    private IRepository<Modulo> _repository;
    private readonly IMapper _mapper;
    public ModuloService(IRepository<Modulo> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(ModuloDTO moduloDto)
    {
        var moduloEntity = _mapper.Map<Modulo>(moduloDto);
        await _repository.CreateAsync(moduloEntity);
    }

    public async Task<ModuloDTO> GetByIdAsync(int? id)
    {
        var moduloEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ModuloDTO>(moduloEntity);
    }

    public async Task<IEnumerable<ModuloDTO>> GetAsync()
    {
        var moduloEntities = await _repository.GetListAsync();
        return _mapper.Map<IEnumerable<ModuloDTO>>(moduloEntities);
    }

    public async Task RemoveAsync(int? id)
    {
        var moduloEntity = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(moduloEntity);
    }

    public async Task UpdateAsync(ModuloDTO modulocategoryDto)
    {
        var moduloEntity = _mapper.Map<Modulo>(modulocategoryDto);
        await _repository.UpdateAsync(moduloEntity);
    }
}