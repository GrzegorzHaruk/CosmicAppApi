using CosmicApp.Domain.Entities;

namespace CosmicApp.Domain.Repositories
{
    public interface IApodRepository
    {
        Task<IEnumerable<Apod>> GetAllAsync();

        Task<Apod?> GetByIdAsync(int id);

        Task<int> CreateAsync(Apod apod);
    }
}
