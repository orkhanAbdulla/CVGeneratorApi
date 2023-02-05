using CVGeneratorApp.Api.Common.Dtos.PersonDtos;

namespace CVGeneratorApp.Api.Services.Abstactions
{
    public interface IPersonService
    {
        public Task<string> CreateAsync(PersonPostDto personPostDto);
    }
}
