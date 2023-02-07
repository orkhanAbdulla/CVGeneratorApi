using AutoMapper;
using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Common.Dtos.SectorDtos;
using CVGeneratorApp.Api.Data;
using CVGeneratorApp.Api.Services.Abstactions;
using Microsoft.EntityFrameworkCore;

namespace CVGeneratorApp.Api.Services.Concrete
{
    public class SectorService : ISectorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SectorsGetDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SectorsGetDto>>(await _context.Sectors.ToListAsync());
        }
    }
}
