using AutoMapper;
using CosmicApp.Domain.Entities;
using CosmicApp.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CosmicApp.Application.Commands.CreateApods
{
    public class CreateApodCommandHandler : IRequestHandler<CreateApodCommand, int>
    {
        private readonly ILogger<CreateApodCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IApodRepository _apodRepository;

        public CreateApodCommandHandler(ILogger<CreateApodCommandHandler> logger, 
            IMapper mapper, IApodRepository apodRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _apodRepository = apodRepository;
        }

        public async Task<int> Handle(CreateApodCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating new APOD");

            var apod = _mapper.Map<Apod>(request);

            int id = await _apodRepository.Create(apod);
            return id;
        }
    }
}
