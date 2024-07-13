using CosmicApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace CosmicApp.Infrastructure.Authorization
{
    public class CosmicAppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public CosmicAppUserClaimsPrincipalFactory(
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var id = await GenerateClaimsAsync(user);

            if (user.Nationality != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));
            }

            if(user.DateOfBirth != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }

            return new ClaimsPrincipal(id);
        }
    }
}
