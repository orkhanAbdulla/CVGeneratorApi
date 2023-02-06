using AutoMapper;
using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Core.Entities;
using CVGeneratorApp.Api.Data;
using CVGeneratorApp.Api.Services.Abstactions;
using CVGeneratorApp.Api.StorageServices.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CVGeneratorApp.Api.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IStorageService _storageService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(IStorageService storageService, ApplicationDbContext context, IMapper mapper)
        {
            _storageService = storageService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> CreateAsync(PersonPostDto personPostDto)
        {
            if (!_context.Sectors.Any(x => x.Id == personPostDto.SectorId)) throw new Exception("Not Found");
            bool checkType = _storageService.CheckFileType(personPostDto.CVFile);
            if (!checkType) throw new Exception("The file must be in PDF format only");//todo FileFormatException
            var result=await _storageService.UploadAsync("CVs",personPostDto.CVFile);
            Person person = _mapper.Map<Person>(personPostDto);
            person.CVFileName=result.fileName;
            person.CVFilePath=result.path;
            person.Created = DateTime.UtcNow.AddHours(4);
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return result.path;
        }

        public async Task<IEnumerable<PersonsGetDto>> GetAllAsync()
        {
          return _mapper.Map<IEnumerable<PersonsGetDto>>(await _context.Persons.Include(x => x.Sector).OrderByDescending(x=>x.Created).ToListAsync());
        }
    }
}
