using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Commands.CreateApod
{
    public class CreateApodCommand : IRequest<int>
    {
        public string? Date { get; set; }

        public string? Explanation { get; set; }

        public string? Url { get; set; }

        public string? Hdurl { get; set; }

        public string? Title { get; set; }

        public string? MediaType { get; set; }

        public CreateApodCommand(ApodDto apodDto)
        {
            Date = apodDto.Date;
            Explanation = apodDto.Explanation;
            Url = apodDto.Url;
            Hdurl = apodDto.Hdurl;
            Title = apodDto.Title;
            MediaType = apodDto.MediaType;
        }
    }
}
