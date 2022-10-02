using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Programa, ProgramaDTO>().ReverseMap();
            CreateMap<Modulo, ModuloDTO>().ReverseMap();
            CreateMap<Tecnologia, TecnologiaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Projeto, ProjetoDTO>().ReverseMap();
            CreateMap<Starter, StarterDTO>().ReverseMap();
            CreateMap<Avaliacao, AvaliacaoDTO>().ReverseMap();

        }
    }
}

//essa classe é responsável por usar a biblioteca AutoMapper para fazer o
// mapeamento automático das entidades do dominio para DTOs.
