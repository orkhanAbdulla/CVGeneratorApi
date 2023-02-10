using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using CVGeneratorApp.Api.Services.Abstactions;
using Microsoft.AspNetCore.Authorization;
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);
            return Ok();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _personService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] PersonsGetFilteredDto personsGetFilteredDto)
        {
            return Ok(await _personService.GetAllAsync(personsGetFilteredDto));
        }
    }
}
