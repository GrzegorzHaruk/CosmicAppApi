using AutoMapper;
using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using CosmicApp.Domain.Entities;
using CosmicApp.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace CosmicApp.Application.Services.Apods
{
    public class ApodService : IApodService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApodRepository _apodRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ApodService(IHttpClientFactory httpClientFactory, IApodRepository apodRepository, 
            ILogger<ApodService> logger, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _apodRepository = apodRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ApodDto> GetNasaApodAsync(DateTime requestDate)
        {
            var client = _httpClientFactory.CreateClient("ApodService");

            var date = requestDate.ToString("yyy-MM-dd");

            var requestString = client.BaseAddress?.ToString() + $"date={date}";

            Uri request = new Uri(client.BaseAddress?.ToString() + $"date={date}");

            var apod = await client.GetFromJsonAsync<Apod>(request);

            var apodDto = _mapper.Map<ApodDto>(apod);

            return apodDto;
        }

        public async Task<IEnumerable<ApodDto>> GetAllApodsAsync()
        {
            _logger.LogInformation("Getting all Astronomy Pictures of the Day (APOD) from the database");
            var apods = await _apodRepository.GetAllAsync();

            var apodsDto = _mapper.Map<IEnumerable<ApodDto>>(apods);
            
            return apodsDto!;
        }

        public async Task<ApodDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Getting Astronomy Picture od the Day (APOD) from the database by id");
            var apod = await _apodRepository.GetById(id);

            var apodDto = _mapper.Map<ApodDto>(apod);

            return apodDto;
        }

        public async Task<int> CreateApodAsync(ApodDto apodDto)
        {
            _logger.LogInformation("Creating Astronomy Picture od the Day (APOD) with id");

            var apod = _mapper.Map<Apod>(apodDto);

            var id = await _apodRepository.Create(apod);

            return id;
        }
    }
}
