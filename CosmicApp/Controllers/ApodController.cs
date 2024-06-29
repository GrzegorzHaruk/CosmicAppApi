using CosmicApp.Core.Models;
using CosmicApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmicApp.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class ApodController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApodService _apodService;

        public ApodController(IHttpClientFactory httpClientFactory, IApodService apodService)
        {
            _httpClientFactory = httpClientFactory;            
            _apodService = apodService;
        }

        [HttpGet("apod")]
        public async Task<Apod> GetApodAsync(DateTime date)
        {
            Apod? apod = await _apodService.GetApodAsunc(date);
            return apod!;
        }
    }
}
