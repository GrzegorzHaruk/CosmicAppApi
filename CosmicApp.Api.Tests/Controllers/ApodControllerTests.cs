using CosmicApp.Domain.Entities;
using CosmicApp.Domain.Repositories;
using CosmicApp.Infrastructure.Seeder;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System.Net;

namespace CosmicApp.Api.Tests.Controllers
{
    public class ApodControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IApodRepository> _apodRepositoryMock = new();
        private readonly Mock<IDataSeeder> _seederMock = new();

        public ApodControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                    services.Replace(ServiceDescriptor.Scoped(typeof(IApodRepository), _ => _apodRepositoryMock.Object));

                    services.Replace(ServiceDescriptor.Scoped(typeof(IDataSeeder), _ => _seederMock.Object));
                });
            });
        }

        [Fact]
        public async Task GetAllApods_ForValidRequest_Returns200Ok()
        {
            // arrange

            var client = _factory.CreateClient();

            // act

            var result = await client.GetAsync("api/apods/all");

            // assert 

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        // to be fixed
        //[Fact]
        //public async Task GetApodByIdAsync_ForNonExistingId_ShouldReturn404NotFound()
        //{
        //    // arrange 
        //    var id = 1123;

        //    _apodRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Apod?)null);

        //    var client = _factory.CreateClient();

        //    // act

        //    var response = await client.GetAsync($"/api/apods/{id}");

        //    // assert 

        //    response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}
    }
}
