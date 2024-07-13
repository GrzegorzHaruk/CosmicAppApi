using CosmicApp.Application.User;
using CosmicApp.Domain.Constants;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace CosmicApp.Application.Tests.User
{
    public class UserContextTests
    {
        [Fact]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // arrange
            var dateOfBirth = new DateOnly(1990, 1, 1);

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, "1"),
                new(ClaimTypes.Email, "test@test.com"),
                new(ClaimTypes.Role, UserRoles.Admin),
                new(ClaimTypes.Role, UserRoles.User),
                new("Nationality", "Martian"),
                new("DateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"))
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext { User = user });

            var userContext = new UserContext(httpContextAccessorMock.Object);

            // act
            var result = userContext.GetCurrentUser();

            // assert

            result.Should().NotBeNull();
            result!.Id.Should().Be("1");
            result.Email.Should().Be("test@test.com");
            result.Roles.Should().ContainInOrder(UserRoles.Admin, UserRoles.User);
            result.Nationality.Should().Be("Martian");
            result.DateOfBirth.Should().Be(dateOfBirth);
        }

        [Fact]
        public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
        {
            // arrange

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null!);

            var currentUser = new UserContext(httpContextAccessorMock.Object);

            // act

            Action action = () => currentUser.GetCurrentUser();

            // assert 

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
