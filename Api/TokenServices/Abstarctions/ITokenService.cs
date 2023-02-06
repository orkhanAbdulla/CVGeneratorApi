using CVGeneratorApp.Api.Common.Models;
using CVGeneratorApp.Api.Entities;

namespace CVGeneratorApp.Api.TokenServices.Abstarctions
{
    public interface ITokenService
    {
        public Token GenerateAccessToken(ApplicationUser user, int day);
    }
}
