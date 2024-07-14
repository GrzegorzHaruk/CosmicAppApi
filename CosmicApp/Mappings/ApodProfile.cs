using AutoMapper;
using CosmicApp.Application.Commands.CreateApods;
using CosmicApp.Application.Models;

namespace CosmicApp.Api.Mappings
{
    public class ApodProfile : Profile
    {
        public ApodProfile()
        {
            CreateMap<ApodDto, CreateApodCommand>();
        }
    }
}
