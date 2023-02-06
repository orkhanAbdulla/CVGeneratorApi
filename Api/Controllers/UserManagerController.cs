using CVGeneratorApp.Api.Common.Dtos.UserDtos;
using CVGeneratorApp.Api.IdentityServices.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGeneratorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserManagerController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            return Ok(await _authService.LoginAsync(userLoginDto));
        }
    }
}
