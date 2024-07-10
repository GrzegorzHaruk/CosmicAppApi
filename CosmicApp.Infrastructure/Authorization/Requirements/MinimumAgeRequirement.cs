using Microsoft.AspNetCore.Authorization;

namespace CosmicApp.Infrastructure.Authorization.Requirements
{
    public class MinimumAgeRequirement(int minimumAge) : IAuthorizationRequirement
    {
        public int MinimumAge { get; } = minimumAge;
    }
}
