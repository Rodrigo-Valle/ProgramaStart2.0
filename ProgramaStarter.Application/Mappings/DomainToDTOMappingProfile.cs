using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<ProgramaStart, ProgramaStartDTO>().ReverseMap();
            CreateMap<Modulo, ModuloDTO>().ReverseMap();
            CreateMap<Tecnologia, TecnologiaDTO>().ReverseMap();
        }
    }
}

//essa classe é responsável por usar a biblioteca AutoMapper para fazer o
// mapeamento automático das entidades do dominio para DTOs.
