using CosmicApp.Application.Interfaces;
using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Commands.CreateApod
{
    public class CreateApodCommandHandler : IRequestHandler<CreateApodCommand, int>
    {
        private readonly IApodService _apodService;

        public CreateApodCommandHandler(IApodService apodService)
        {
            _apodService = apodService ?? throw new ArgumentNullException(nameof(apodService));
        }

        public async Task<int> Handle(CreateApodCommand request, CancellationToken cancellationToken)
        {
            var apodDto = new ApodDto
            {
                Date = request.Date,
                Url = request.Url,
                Hdurl = request.Hdurl,
                Title = request.Title,
                MediaType = request.MediaType,
                Explanation = request.Explanation
            };

            var result = await _apodService.CreateApodAsync(apodDto);
            return result;
        }
    }
}
