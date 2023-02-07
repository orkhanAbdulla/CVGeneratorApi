using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Common.Dtos.SectorDtos;

namespace CVGeneratorApp.Api.Services.Abstactions
{
    public interface ISectorService
    {
        public Task<IEnumerable<SectorsGetDto>> GetAllAsync();
    }
}
