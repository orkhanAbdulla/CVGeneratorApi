using CVGeneratorApp.Api.Common.Dtos.UserDtos;
using CVGeneratorApp.Api.Common.Models;
using CVGeneratorApp.Api.Entities;
using CVGeneratorApp.Api.IdentityServices.Abstractions;
using CVGeneratorApp.Api.TokenServices.Abstarctions;
using Microsoft.AspNetCore.Identity;

namespace CVGeneratorApp.Api.IdentityServices.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<Token> LoginAsync(UserLoginDto userLoginDto)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            if (user is null) throw new UnauthorizedAccessException("The email or password is incorrect");
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);
            if (!result.Succeeded) throw new UnauthorizedAccessException("The email or password is incorrect");
            return _tokenService.GenerateAccessToken(user,7);
        }
    }
}
