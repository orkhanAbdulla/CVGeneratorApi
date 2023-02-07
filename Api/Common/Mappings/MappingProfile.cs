using AutoMapper;
using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Common.Dtos.SectorDtos;
using CVGeneratorApp.Api.Core.Entities;

namespace CVGeneratorApp.Api.Common.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonPostDto, Person>();
            CreateMap<Person,PersonsGetDto>().ForMember(dest=>dest.SectorName,opt=>opt.MapFrom(src=>src.Sector.Name));
            CreateMap<Sector, SectorsGetDto>();
        }
    }
}
