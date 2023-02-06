using CVGeneratorApp.Api.Common.Dtos.UserDtos;
using FluentValidation;

namespace CVGeneratorApp.Api.Common.Validators
{
    public class UserLoginDtoValidation:AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
