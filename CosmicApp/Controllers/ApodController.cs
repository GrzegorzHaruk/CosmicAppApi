using CosmicApp.Application.Interfaces;
using CosmicApp.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace CosmicApp.Api.Controllers
{
    [ApiController]
    [Route("api/apods")]
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
        public async Task<IActionResult> GetApodAsync(DateTime date)
        {
            var apod = await _apodService.GetNasaApodAsync(date);
            return Ok(apod);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllApods()
        {
            var result = await _apodService.GetAllApodsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApodById([FromRoute] int id)
        {
            var apod = await _apodService.GetByIdAsync(id);

            if (apod == null)
            {
                return NotFound();
            }

            return Ok(apod);
        }
    }
}
