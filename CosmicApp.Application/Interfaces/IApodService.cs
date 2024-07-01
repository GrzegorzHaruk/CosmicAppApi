using CosmicApp.Application.Models;

namespace CosmicApp.Application.Interfaces
{
    public interface IApodService
    {
        Task<IEnumerable<ApodDto>> GetAllApodsAsync();
        
        Task<ApodDto> GetNasaApodAsync(DateTime requestDate);

        Task<ApodDto?> GetByIdAsync(int id);
    }
}