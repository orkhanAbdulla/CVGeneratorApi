using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Common.Models;

namespace CVGeneratorApp.Api.Services.Abstactions
{
    public interface IPersonService
    {
        public Task<string> CreateAsync(PersonPostDto personPostDto);
        public Task<IEnumerable<PersonsGetDto>> GetAllAsync();
        public Task<PaginatedList<PersonsGetDto>> GetAllAsync(PersonsGetFilteredDto personsGetFilteredDto);
    }
}
