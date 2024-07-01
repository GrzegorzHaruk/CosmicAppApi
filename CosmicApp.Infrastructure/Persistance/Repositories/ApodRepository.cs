using CosmicApp.Domain.Entities;
using CosmicApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CosmicApp.Infrastructure.Persistance.Repositories
{
    internal class ApodRepository : IApodRepository
    {
        private readonly ApodDbContext _apodDbContext;

        public ApodRepository(ApodDbContext apodDbContext)
        {
            _apodDbContext = apodDbContext; 
        }

        public async Task<IEnumerable<Apod>> GetAllAsync()
        {
            var result = await _apodDbContext.Apods.ToListAsync();

            return result;
        }
        
        public async Task<Apod?> GetById(int id)
        {
            var result = await _apodDbContext.Apods.SingleOrDefaultAsync(x=>x.Id == id);
            return result;
        }
    }
}
