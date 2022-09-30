using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class TecnologiaService : ITecnologiaService
{
    private IRepository<Tecnologia> _repository;
    private readonly IMapper _mapper;
    public TecnologiaService(IRepository<Tecnologia> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(TecnologiaDTO tecnologiaDto)
    {
        var tecnologiaEntidade = _mapper.Map<Tecnologia>(tecnologiaDto);
        await _repository.CreateAsync(tecnologiaEntidade);
    }

    public async Task<TecnologiaDTO> GetByIdAsync(int? id)
    {
        var tecnologiaEntidade = await _repository.GetByIdAsync(id);
        return _mapper.Map<TecnologiaDTO>(tecnologiaEntidade);
    }

    public async Task<IEnumerable<TecnologiaDTO>> GetAsync()
    {
        var tecnologiaEntidade = await _repository.GetListAsync();
        return _mapper.Map<IEnumerable<TecnologiaDTO>>(tecnologiaEntidade);
    }

    public async Task RemoveAsync(int? id)
    {
        var tecnologiaEntidade = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(tecnologiaEntidade);
    }

    public async Task UpdateAsync(TecnologiaDTO tecnologiaDto)
    {
        var tecnologiaEntidade = _mapper.Map<Tecnologia>(tecnologiaDto);
        await _repository.UpdateAsync(tecnologiaEntidade);
    }
}