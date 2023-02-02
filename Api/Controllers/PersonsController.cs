using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGeneratorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
    }
}
