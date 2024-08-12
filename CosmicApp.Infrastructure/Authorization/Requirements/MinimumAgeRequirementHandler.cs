using CosmicApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CosmicApp.Infrastructure.Authorization.Requirements
{
    public class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger,
        IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            MinimumAgeRequirement requirement)
        {
            var currentUser = userContext.GetCurrentUser();
            logger.LogInformation($"User: {currentUser.Email}, date of birth: " +
                $"{currentUser.DateOfBirth} - Handling Minimum Age Requirement");

            if(currentUser.DateOfBirth == null)
            {
                logger.LogWarning("User date of birth is null");
                context.Fail();
                return Task.CompletedTask;
            }

            if(currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
            {
                logger.LogInformation("Authorization succeeded");
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
