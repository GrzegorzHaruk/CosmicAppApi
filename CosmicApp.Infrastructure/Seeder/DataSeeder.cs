using CosmicApp.Domain.Constants;
using CosmicApp.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace CosmicApp.Infrastructure.Seeder
{
    internal class DataSeeder(ApodDbContext apodDbContext) : IDataSeeder
    {
        public async Task Seed()
        {
            if (!apodDbContext.Roles.Any())
            {
                var roles = GetRoles();
                apodDbContext.AddRange(roles);
                await apodDbContext.SaveChangesAsync();
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.User){
                        NormalizedName = UserRoles.User.ToUpper(),
                    },
                    new (UserRoles.Owner){
                        NormalizedName = UserRoles.Owner.ToUpper(),
                    },
                    new (UserRoles.Admin){
                        NormalizedName = (UserRoles.Admin.ToUpper())
                    }
                ];

            return roles;
        }
    }
}
