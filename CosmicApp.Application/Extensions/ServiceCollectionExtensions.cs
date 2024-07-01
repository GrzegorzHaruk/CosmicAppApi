using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Services.Apods;
using Microsoft.Extensions.DependencyInjection;

namespace CosmicApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IApodService, ApodService>();
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
