using CosmicApp.Application.Models;
using FluentValidation;

namespace CosmicApp.Application.Validators
{
    public class ApodProfile : AbstractValidator<ApodDto>
    {
        public ApodProfile()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("Too long");
            
            RuleFor(x=>x.Url)
                .NotEmpty()
                .WithMessage("Can't be empty");
        }
    }
}
