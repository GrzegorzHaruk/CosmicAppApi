using CosmicApp.Application.Models;
using FluentValidation;

namespace CosmicApp.Application.Validators
{
    public class CreateApodDtoValidator : AbstractValidator<ApodDto>
    {
        public CreateApodDtoValidator()
        {
            RuleFor(x => x.Url)
                .NotEmpty()
                .WithMessage("Provide a valid APOD url");
        }
    }
}
