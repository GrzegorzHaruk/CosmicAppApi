using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetAllApods
{
    public class GetAllApodsQueryHandler : IRequestHandler<GetAllApodsQuery, IEnumerable<ApodDto>>
    {
        private readonly IApodService _apodService;

        public GetAllApodsQueryHandler(IApodService apodService)
        {
            _apodService = apodService ?? throw new ArgumentNullException(nameof(apodService));
        }

        public async Task<IEnumerable<ApodDto>> Handle(GetAllApodsQuery request, CancellationToken cancellationToken)
        {
            var apods = await _apodService.GetAllApodsAsync();

            return apods;
        }
    }
}
