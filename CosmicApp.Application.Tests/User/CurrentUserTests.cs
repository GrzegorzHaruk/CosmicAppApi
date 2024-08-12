using CosmicApp.Application.User;
using CosmicApp.Domain.Constants;
using FluentAssertions;

namespace CosmicApp.Application.Tests.User
{
    public class CurrentUserTests
    {
        [Theory]
        [InlineData(UserRoles.User)]
        [InlineData(UserRoles.Admin)]
        public void IsInRole_IsInMatchingRole_ShouldReturnTrue(string userRole)
        {
            var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.User, UserRoles.Admin], null, null);

            var result = currentUser.IsInRole(userRole);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsInRole_WithoutMatchingRole_ShouldReturnFalse()
        {
            var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.User, UserRoles.Admin], null, null);

            var result = currentUser.IsInRole(UserRoles.Owner);

            result.Should().BeFalse();
        }
    }
}
