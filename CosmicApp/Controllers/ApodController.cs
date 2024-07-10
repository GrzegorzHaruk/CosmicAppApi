﻿using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using CosmicApp.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CosmicApp.Api.Controllers
{
    [ApiController]
    [Route("api/apods")]
    [Authorize]
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
        //[Authorize(Roles = UserRoles.Owner)]
        //[Authorize(Policy = PolicyNames.HasNationality)]
        [Authorize(Policy = PolicyNames.AtLeast20)]
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

        [HttpPost]
        public async Task<IActionResult> CreateApod([FromBody] ApodDto apodDto)
        {
            int id = await _apodService.CreateApodAsync(apodDto);

            return CreatedAtAction(nameof(GetApodById), new {id}, null);
        }
    }
}
