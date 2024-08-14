using CosmicApp.Application.Commands.CreateApod;
using CosmicApp.Application.Models;
using CosmicApp.Application.Queries.GetAllApods;
using CosmicApp.Application.Queries.GetApodById;
using CosmicApp.Application.Queries.GetNasaApod;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CosmicApp.Api.Controllers
{
    [ApiController]
    [Route("api/apods")]
    public class ApodController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMediator _mediator;

        public ApodController(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            _httpClientFactory = httpClientFactory;
            _mediator = mediator;
        }

        [HttpGet("apod")]
        public async Task<IActionResult> GetApodAsync(DateTime date)
        {
            var apod = await _mediator.Send(new GetNasaApodQuery(date));
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
            var apod = await _mediator.Send(new GetApodByIdQuery(id));

            if (apod == null)
            {
                return NotFound();
            }

            return Ok(apod);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApod([FromBody] ApodDto apodDto)
        {
            var id = await _mediator.Send(new CreateApodCommand(apodDto));

            return CreatedAtAction(nameof(GetApodById), new { id }, null);
        }
    }
}
