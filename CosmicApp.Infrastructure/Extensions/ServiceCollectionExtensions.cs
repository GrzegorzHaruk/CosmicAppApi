using CosmicApp.Domain.Entities;
using CosmicApp.Domain.Repositories;
using CosmicApp.Infrastructure.Authorization;
using CosmicApp.Infrastructure.Authorization.Requirements;
using CosmicApp.Infrastructure.Persistance;
using CosmicApp.Infrastructure.Persistance.Repositories;
using CosmicApp.Infrastructure.Seeder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CosmicApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<ApodDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<CosmicAppUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<ApodDbContext>();

            services.AddScoped<IApodRepository, ApodRepository>();

            services.AddScoped<IDataSeeder, DataSeeder>();

            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyNames.HasNationality, 
                    builer => builer.RequireClaim(AppClaimTypes.Nationality, "Martian"))
                .AddPolicy(PolicyNames.AtLeast20,
                    builder=>builder.AddRequirements(new MinimumAgeRequirement(20)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
        }
    }
}
