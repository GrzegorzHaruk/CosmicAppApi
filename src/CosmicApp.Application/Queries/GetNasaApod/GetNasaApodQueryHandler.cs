using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetNasaApod
{
    public class GetNasaApodQueryHandler : IRequestHandler<GetNasaApodQuery, ApodDto>
    {
        private readonly IApodService _apodService;

        public GetNasaApodQueryHandler(IApodService apodService)
        {
            _apodService = apodService ?? throw new ArgumentNullException(nameof(apodService));
        }

        public async Task<ApodDto> Handle(GetNasaApodQuery request, CancellationToken cancellationToken)
        {
            var apod = await _apodService.GetNasaApodAsync(request.Date);

            return apod;
        }
    }
}
