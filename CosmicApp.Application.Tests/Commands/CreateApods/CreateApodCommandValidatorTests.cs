using CosmicApp.Application.Commands.CreateApods;
using FluentValidation.TestHelper;

namespace CosmicApp.Application.Tests.Commands.CreateApods
{
    public class CreateApodCommandValidatorTests
    {
        [Fact]
        public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
        {
            // arrange 
            var command = new CreateApodCommand()
            {
                Url = "testUrl"
            };

            var validator = new CreateApodCommandValidator();

            // act 

            var result = validator.TestValidate(command);
            var result2 = validator.Validate(command);

            // assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
        {
            // arrange 
            var command = new CreateApodCommand()
            {
                Url = string.Empty
            };

            var validator = new CreateApodCommandValidator();

            // act 

            var result = validator.TestValidate(command);

            // assert

            result.ShouldHaveValidationErrorFor(x => x.Url);
        }
    }
}
