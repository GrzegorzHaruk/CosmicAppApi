using CosmicApp.Core.Models;
using CosmicApp.Core.Services;
using Microsoft.Extensions.Options;
using CosmicApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Cosmic App",
        Version = "v1"
    });
});

builder.Services.Configure<NasaApiOptions>(builder.Configuration.GetSection("NasaApiOptions"));

builder.Services.AddHttpClient("ApodService", (options, client) =>
{
    var apiKey = options.GetRequiredService<IOptions<NasaApiOptions>>().Value;

    client.BaseAddress = new Uri($"https://api.nasa.gov/planetary/apod?api_key={apiKey.NasaApiKey}&");
});

builder.Services.AddTransient<IApodService, ApodService>();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

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

//app.UseAuthorization();

app.MapControllers();

app.Run();
