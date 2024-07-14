using CosmicApp.Api.Extensions;
using CosmicApp.Application.Extensions;
using CosmicApp.Application.Models;
using CosmicApp.Domain.Entities;
using CosmicApp.Infrastructure.Extensions;
using CosmicApp.Infrastructure.Seeder;
using Microsoft.Extensions.Options;

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

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
await seeder.Seed();

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

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }