using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace CosmicApp.Api.Tests.Controllers
{
    public class ApodControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ApodControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
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
    }
}
