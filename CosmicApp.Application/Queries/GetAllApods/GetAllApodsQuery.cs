using CosmicApp.Application.Models;
using MediatR;

namespace CosmicApp.Application.Queries.GetAllApods
{
    public class GetAllApodsQuery : IRequest<IEnumerable<ApodDto>>
    {
    }
}
