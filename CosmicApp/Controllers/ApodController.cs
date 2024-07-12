﻿using AutoMapper;
using CosmicApp.Application.Commands.CreateApods;
using CosmicApp.Application.Models;
using CosmicApp.Application.Queries.GetAllApods;
using CosmicApp.Application.Queries.GetApodById;
using CosmicApp.Application.Queries.GetNasaApodByDate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CosmicApp.Api.Controllers
{
    [ApiController]
    [Route("api/apods")]
    //[Authorize]
    public class ApodController : ControllerBase
    {        
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ApodController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("date")]
        public async Task<IActionResult> GetNasaApodAsync(DateTime date)
        {
            var apod = await _mediator.Send(new GetNasaApodByDateQuery { Date = date });
            return Ok(apod);
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetApodByIdAsync(int id)
        {
            var apod = await _mediator.Send(new GetApodByIdQuery() { Id = id });
            return Ok(apod);
        }

        [HttpGet("all")]        
        public async Task<IActionResult> GetAllApods()
        {
            var result = await _mediator.Send(new GetAllApodsQuery());
            return Ok(result);
        }        

        [HttpPost]
        public async Task<IActionResult> CreateApod([FromBody] ApodDto apodDto)
        {
            int id = await _mediator.Send(_mapper.Map<CreateApodCommand>(apodDto));
            
            return Ok(id);
        }
    }
}
