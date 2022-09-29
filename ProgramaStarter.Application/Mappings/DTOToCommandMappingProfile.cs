using AutoMapper;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProgramaStartDTO, ProgramaStart>();
        }
    }
}
