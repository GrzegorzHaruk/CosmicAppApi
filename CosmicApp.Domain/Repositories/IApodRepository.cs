using CosmicApp.Domain.Entities;

namespace CosmicApp.Domain.Repositories
{
    public interface IApodRepository
    {
        Task<IEnumerable<Apod>> GetAllAsync();
        Task<Apod?> GetById(int id);
    }
}
