using CosmicApp.Application.Models;
using FluentValidation;

namespace CosmicApp.Application.Commands.CreateApods
{
    public class CreateApodCommandValidator : AbstractValidator<CreateApodCommand>
    {
        public CreateApodCommandValidator()
        {
            RuleFor(x => x.Url)
                .NotEmpty()
                .WithMessage("Provide a valid APOD url");
        }
    }
}
