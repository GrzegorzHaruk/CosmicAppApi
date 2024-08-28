using CosmicApp.Application.Models;
using CosmicApp.Application.Validators;
using FluentAssertions;

namespace CosmicApp.Application.Tests.Validator
{
    public class ApodValidatorTests
    {
        private ApodProfile _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new ApodProfile();
        }

        [Test]
        public void WithValidDto_ValidationShouldPass()
        {
            // Arrange            
            var apodDto = new ApodDto() { Title = "TestTitle", Url = "TestUrl" };

            // Act
            var result = _validator.Validate(apodDto);

            // Assert
            result.Errors.Should().HaveCount(0);
            result.IsValid.Should().BeTrue();
        }

        [Test]
        public void WithTooLongApodTitle_ValidationShouldFail_WithProperErrorMessage()
        {
            // Arrange    
            var apodDto = new ApodDto() { Title = "TestTestTestTestTestTest", Url = "TestUrl" };

            // Act
            var result = _validator.Validate(apodDto);

            // Assert
            Assert.Multiple(() => 
            {
                result.Errors.Should().HaveCount(1);
                result.Errors[0].ErrorMessage.Should().Be("Too long");   
                result.IsValid.Should().BeFalse();
            });
        }

        [Test]
        public void WithTooLongApodUrl_ValidationShouldFail_WithProperErrorMessage()
        {
            // Arrange    
            var apodDto = new ApodDto() { Title = "Test", Url = string.Empty };

            // Act
            var result = _validator.Validate(apodDto);

            // Assert
            Assert.Multiple(() =>
            {
                result.Errors.Should().HaveCount(1);                
                result.Errors[0].ErrorMessage.Should().Be("Can't be empty");
                result.IsValid.Should().BeFalse();
            });
        }
    }
}
