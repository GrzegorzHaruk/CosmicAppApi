using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetNasaApodByDate
{
    public class GetNasaApodByDateQueryHandler : IRequestHandler<GetNasaApodByDateQuery, ApodDto?>
    {
        private readonly IApodService _apodService;

        public GetNasaApodByDateQueryHandler(IApodService apodService)
        {
            _apodService = apodService;
        }

        public async Task<ApodDto?> Handle(GetNasaApodByDateQuery request, CancellationToken cancellationToken)
        {
            var apod = await _apodService.GetNasaApodAsync(request.Date);

            return apod;
        }
    }
}
