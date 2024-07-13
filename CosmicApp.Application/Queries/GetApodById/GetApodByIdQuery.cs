using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetApodById
{
    public class GetApodByIdQuery : IRequest<ApodDto?>
    {
        public int Id { get; set; }
    }
}
