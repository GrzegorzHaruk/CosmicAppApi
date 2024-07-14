using CosmicApp.Application.Queries.GetNasaApodByDate;
using FluentValidation.TestHelper;

namespace CosmicApp.Application.Tests.Queries.GetNasaApodByDate
{
    public class GetNasaApodByDateQueryValidatorTests
    {
        [Theory, MemberData(nameof(Cases))]
        public void Validator_ValidQuery_ShouldNotHaveValidationErrors(DateTime date)
        {
            // arrange
            var query = new GetNasaApodByDateQuery
            {
                Date = date
            };

            var validator = new GetNasaApodByDateQueryValidator();

            // act

            var result = validator.TestValidate(query);

            // assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validator_InvalidQuery_ShouldHaveValidationErrors()
        {
            // arrange
            var query = new GetNasaApodByDateQuery() { Date = DateTime.UtcNow.AddDays(1) };

            var validator = new GetNasaApodByDateQueryValidator();

            // act

            var result = validator.TestValidate(query);

            // assert

            result.ShouldHaveAnyValidationError();
        }

        public static TheoryData<DateTime> Cases = new()
        {
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(-1),
        };
    }
}
