using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Account;
using ProgramaStarter.Domain.Entities;
using ProgramaStarter.Domain.Interfaces;

namespace ProgramaStarter.Application.Services;
public class UsuarioService : IUsuarioService
{
    private IRepository<Usuario> _repository;
    private readonly IMapper _mapper;
    public UsuarioService(IRepository<Usuario> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task AddAsync(UsuarioDTO usuarioDto)
    {
        var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
        await _repository.CreateAsync(usuarioEntity);
    }

    public async Task<UsuarioDTO> GetByIdAsync(int? id)
    {
        var usuarioEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<UsuarioDTO>(usuarioEntity);
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAsync()
    {
        var usuarioEntities = await _repository.GetListAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarioEntities);
    }

    public async Task RemoveAsync(int? id)
    {
        var usuarioEntity = _repository.GetByIdAsync(id).Result;
        await _repository.RemoveAsync(usuarioEntity);
    }

    public async Task UpdateAsync(UsuarioDTO usuariocategoryDto)
    {
        var usuarioEntity = _mapper.Map<Usuario>(usuariocategoryDto);
        await _repository.UpdateAsync(usuarioEntity);
    }
}