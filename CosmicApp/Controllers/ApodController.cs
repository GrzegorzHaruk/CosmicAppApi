using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using CosmicApp.Application.Queries.GetAllApods;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CosmicApp.Api.Controllers
{
    [ApiController]
    [Route("api/apods")]
    //[Authorize]
    public class ApodController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApodService _apodService;
        private readonly IMediator _mediator;

        public ApodController(IHttpClientFactory httpClientFactory, IApodService apodService, IMediator mediator)
        {
            _httpClientFactory = httpClientFactory;
            _apodService = apodService;
            _mediator = mediator;
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
            var result = await _mediator.Send(new GetAllApodsQuery());
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

        [HttpPost]
        public async Task<IActionResult> CreateApod([FromBody] ApodDto apodDto)
        {
            int id = await _apodService.CreateApodAsync(apodDto);

            return CreatedAtAction(nameof(GetApodById), new { id }, null);
        }
    }
}
