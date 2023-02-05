using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Services.Abstactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGeneratorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm]PersonPostDto personPostDto)
        {
            return Ok(await _personService.CreateAsync(personPostDto));
        }
    }
}
