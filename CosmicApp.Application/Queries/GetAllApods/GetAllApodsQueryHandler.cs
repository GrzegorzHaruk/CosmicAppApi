using AutoMapper;
using CosmicApp.Application.Models;
using CosmicApp.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CosmicApp.Application.Queries.GetAllApods
{
    public class GetAllApodsQueryHandler(ILogger<GetAllApodsQueryHandler> logger, 
        IApodRepository apodRepository,
        IMapper mapper) : IRequestHandler<GetAllApodsQuery, IEnumerable<ApodDto>>
    {
        public async Task<IEnumerable<ApodDto>> Handle(GetAllApodsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all Astronomy Pictures od the Day (APOD) from the database");
            var apods = await apodRepository.GetAllAsync();

            var apodsDto = mapper.Map<IEnumerable<ApodDto>>(apods);

            return apodsDto!;
        }
    }
}
