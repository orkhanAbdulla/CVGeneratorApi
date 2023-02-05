using AutoMapper;
using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Core.Entities;

namespace CVGeneratorApp.Api.Common.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonPostDto, Person>();
        }
    }
}
