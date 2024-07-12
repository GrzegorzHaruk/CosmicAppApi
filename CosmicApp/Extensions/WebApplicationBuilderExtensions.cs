using Microsoft.OpenApi.Models;


namespace CosmicApp.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(setup =>
            {
                setup.AddSecurityDefinition("bearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                        },
                        []
                    }
                });

                setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Cosmic App",
                    Version = "v1"
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(WebApplicationBuilderExtensions).Assembly);
        }
    }
}
