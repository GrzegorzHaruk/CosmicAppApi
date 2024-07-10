using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Services.Apods;
using CosmicApp.Application.User;
using Microsoft.Extensions.DependencyInjection;

namespace CosmicApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IApodService, ApodService>();
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
