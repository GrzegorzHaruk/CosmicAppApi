using AutoMapper;
using CosmicApp.Application.Commands.CreateApods;
using CosmicApp.Application.Models;
using CosmicApp.Domain.Entities;

namespace CosmicApp.Application.Mappings
{
    public class ApodProfile : Profile
    {
        public ApodProfile()
        {
            CreateMap<Apod, ApodDto>().ReverseMap();

            CreateMap<CreateApodCommand, ApodDto>();
        }
    }
}
