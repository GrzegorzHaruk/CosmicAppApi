using FluentValidation;

namespace CosmicApp.Application.Queries.GetNasaApodByDate
{
    public class GetNasaApodByDateQueryValidator : AbstractValidator<GetNasaApodByDateQuery>
    {
        public GetNasaApodByDateQueryValidator()
        {
            RuleFor(x=>x.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Latest date should be today");
        }
    }
}
