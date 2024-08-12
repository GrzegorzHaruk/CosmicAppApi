using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetNasaApodByDate
{
    public class GetNasaApodByDateQuery : IRequest<ApodDto?>
    {
        public DateTime Date { get; set; }
    }
}
