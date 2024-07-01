using CosmicApp.Core.Models;
using CosmicApp.Domain.Entities;

namespace CosmicApp.Core.Services
{
    public interface IApodService
    {
        Task<Apod> GetApodAsync(DateTime requestDate);
    }
}