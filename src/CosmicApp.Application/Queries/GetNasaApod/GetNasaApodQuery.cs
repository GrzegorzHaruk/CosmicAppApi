using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetNasaApod
{
    public class GetNasaApodQuery : IRequest<ApodDto>
    {
        public DateTime Date { get; set; }

        public GetNasaApodQuery(DateTime date)
        {
            Date = date;
        }
    }
}
