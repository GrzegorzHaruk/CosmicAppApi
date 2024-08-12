using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CosmicApp.Application.Commands.CreateApods
{
    public class CreateApodCommandHandler : IRequestHandler<CreateApodCommand, int>
    {
        private readonly ILogger<CreateApodCommandHandler> _logger;
        private readonly IApodService _apodService;

        public CreateApodCommandHandler(ILogger<CreateApodCommandHandler> logger, IApodService apodService)
        {
            _logger = logger;            
            _apodService = apodService;
        }

        public async Task<int> Handle(CreateApodCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating new APOD");

            var apodDto = new ApodDto
            {
                Date = request.Date,
                Explanation = request.Explanation,
                Url = request.Url,
                Hdurl = request.Hdurl,
                Title = request.Title,
                MediaType = request.MediaType,
            };

            var id = await _apodService.CreateApodAsync(apodDto);
            
            return id;
        }
    }
}
