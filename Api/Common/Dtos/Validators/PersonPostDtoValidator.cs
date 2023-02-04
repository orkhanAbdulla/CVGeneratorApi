using CVGeneratorApp.Api.Common.Dtos.PersonDtos;
using FluentValidation;

namespace CVGeneratorApp.Api.Common.Dtos.Validators
{
    public class PersonPostDtoValidator : AbstractValidator<PersonPostDto>
    {
        public PersonPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(256);
            RuleFor(x=>x.Surname).MaximumLength(256);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.MobilePhone).Null().NotEmpty().MaximumLength(50);
            RuleFor(x => x.CVFile).NotNull().NotEmpty();
        }
    }

}
