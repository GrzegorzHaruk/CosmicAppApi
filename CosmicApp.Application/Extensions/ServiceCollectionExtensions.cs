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
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddScoped<IApodService, ApodService>();
            services.AddAutoMapper(assembly);
            services.AddScoped<IUserContext, UserContext>();
            services.AddValidatorsFromAssembly(assembly).AddFluentValidationAutoValidation();
        }
    }
}
