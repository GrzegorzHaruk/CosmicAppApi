using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Services.Apods;
using CosmicApp.Application.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CosmicApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
<<<<<<< HEAD:src/CosmicApp.Application/Extensions/ServiceCollectionExtensions.cs
            services.AddScoped<IApodService, ApodService>();            
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
=======
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddScoped<IApodService, ApodService>();
            services.AddAutoMapper(assembly);
            services.AddScoped<IUserContext, UserContext>();
            services.AddValidatorsFromAssembly(assembly).AddFluentValidationAutoValidation();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
>>>>>>> development:CosmicApp.Application/Extensions/ServiceCollectionExtensions.cs
        }
    }
}
