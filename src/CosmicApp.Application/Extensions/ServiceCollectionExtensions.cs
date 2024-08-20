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
            var appAssembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appAssembly));
            services.AddAutoMapper(appAssembly);
            services.AddValidatorsFromAssembly(appAssembly).AddFluentValidationAutoValidation();

            services.AddScoped<IApodService, ApodService>();

            services.AddScoped<IUserContext, UserContext>();
            services.AddHttpContextAccessor();
        }
    }
}
