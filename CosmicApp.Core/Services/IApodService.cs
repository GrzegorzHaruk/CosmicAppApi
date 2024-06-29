using CosmicApp.Core.Models;

namespace CosmicApp.Core.Services
{
    public interface IApodService
    {
        Task<Apod> GetApodAsunc(DateTime requestDate);
    }
}