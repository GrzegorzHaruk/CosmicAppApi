using CosmicApp.Api.Extensions;
using CosmicApp.Application.Extensions;
using CosmicApp.Application.Models;
using CosmicApp.Domain.Entities;
using CosmicApp.Infrastructure.Extensions;
using CosmicApp.Infrastructure.Seeders;
using Microsoft.Extensions.Options;
using Serilog;

try
{


    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddCors();

    builder.Services.Configure<NasaApiOptions>(builder.Configuration.GetSection("NasaApiOptions"));

    builder.Services.AddHttpClient("ApodService", (options, client) =>
    {
        var apiKey = options.GetRequiredService<IOptions<NasaApiOptions>>().Value;

        client.BaseAddress = new Uri($"https://api.nasa.gov/planetary/apod?api_key={apiKey.NasaApiKey}&");
    });

    builder.AddPresentation();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();

    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

    var app = builder.Build();

    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
    await seeder.Seed();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(options => options.WithOrigins().AllowAnyOrigin());

    app.UseHttpsRedirection();

    app.MapGroup("api/identity").MapIdentityApi<User>();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

catch (Exception e)
{
    Log.Fatal(e, "App exploded on start");
}

finally
{
    Log.CloseAndFlush();
}