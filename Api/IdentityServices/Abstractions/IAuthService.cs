using CVGeneratorApp.Api.Common.Dtos.UserDtos;
using CVGeneratorApp.Api.Common.Models;

namespace CVGeneratorApp.Api.IdentityServices.Abstractions
{
    public interface IAuthService
    {
        public Task<Token> LoginAsync(UserLoginDto userLoginDto);
    }
}
