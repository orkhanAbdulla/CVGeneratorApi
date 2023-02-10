using CVGeneratorApp.Api.Common.Mappings;
using CVGeneratorApp.Api.Core.Entities;

namespace CVGeneratorApp.Api.Common.Dtos.PersonDtos
{
    public class PersonsGetDto:IMapFrom<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobilePhone { get; set; }=null!;
        public string SectorName { get; set; } = null!;
        public string CVFilePath { get; set; } = null!;
    }
}
