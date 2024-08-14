using CosmicApp.Domain.Constants;
using CosmicApp.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace CosmicApp.Infrastructure.Seeders
{
    internal class Seeder(ApodDbContext apodDbContext) : ISeeder
    {
        public async Task Seed()
        {
            if (await apodDbContext.Database.CanConnectAsync())
            {
                if (!apodDbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    apodDbContext.Roles.AddRange(roles);
                    await apodDbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> identityRoles = new List<IdentityRole>()
            {
                new(UserRoles.User),
                new(UserRoles.Owner),
                new(UserRoles.Admin)
            };

            return identityRoles;
        }
    }
}
