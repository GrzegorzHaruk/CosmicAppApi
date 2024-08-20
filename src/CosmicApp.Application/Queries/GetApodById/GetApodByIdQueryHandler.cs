using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetApodById
{
    public class GetApodByIdQueryHandler : IRequestHandler<GetApodByIdQuery, ApodDto>
    {
        private readonly IApodService _apodService;

        public GetApodByIdQueryHandler(IApodService apodService)
        {
            _apodService = apodService ?? throw new ArgumentNullException(nameof(apodService));
        }

        public async Task<ApodDto> Handle(GetApodByIdQuery request, CancellationToken cancellationToken)
        {
            var apod = await _apodService.GetByIdAsync(request.Id);
            return apod!;
        }
    }
}
