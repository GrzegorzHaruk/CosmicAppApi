using CosmicApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CosmicApp.Infrastructure.Persistance
{
    internal class ApodDbContext : DbContext
    {
        internal DbSet<Apod> Apods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CosmicDb;Trusted_Connection=True;");
        }
    }
}
