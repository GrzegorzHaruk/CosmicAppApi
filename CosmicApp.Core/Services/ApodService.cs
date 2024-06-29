using CosmicApp.Core.Models;
using System.Net.Http.Json;

namespace CosmicApp.Core.Services
{
    public class ApodService : IApodService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApodService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Apod> GetApodAsunc(DateTime requestDate)
        {
            var client = _httpClientFactory.CreateClient("ApodService");

            var date = requestDate.ToString("yyy-MM-dd");

            var requestString = client.BaseAddress?.ToString()+ $"date={date}";

            Uri request = new Uri(client.BaseAddress?.ToString() + $"date={date}");

            var apod = await client.GetFromJsonAsync<Apod>(request);
            return apod!;
        }
    }
}
