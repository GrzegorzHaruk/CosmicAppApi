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
        
        public async Task<Apod?> GetByIdAsync(int id)
        {
            var result = await _apodDbContext.Apods.SingleOrDefaultAsync(x=>x.Id == id);
            
            return result;
        }

        public async Task<int> CreateAsync(Apod apod)
        {
            _apodDbContext.Apods.Add(apod);
            await _apodDbContext.SaveChangesAsync();
            return apod.Id;
        }
    }
}
