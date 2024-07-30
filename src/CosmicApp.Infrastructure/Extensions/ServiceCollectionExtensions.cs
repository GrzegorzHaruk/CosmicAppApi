using CosmicApp.Domain.Repositories;
using CosmicApp.Infrastructure.Persistance;
using CosmicApp.Infrastructure.Persistance.Repositories;
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
        }
    }
}
