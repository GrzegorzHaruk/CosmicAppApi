using CosmicApp.Domain.Entities;
using CosmicApp.Domain.Repositories;
using CosmicApp.Infrastructure.Persistance;
using CosmicApp.Infrastructure.Persistance.Repositories;
using CosmicApp.Infrastructure.Seeders;
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
            var connectionString = configuration.GetConnectionString("CosmicDb");
            services.AddDbContext<ApodDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IApodRepository, ApodRepository>();
            services.AddScoped<ISeeder, Seeder>();

            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApodDbContext>();
        }
    }
}
