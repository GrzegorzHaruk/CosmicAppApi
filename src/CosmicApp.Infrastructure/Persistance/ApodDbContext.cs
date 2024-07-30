using CosmicApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CosmicApp.Infrastructure.Persistance
{
    internal class ApodDbContext : DbContext
    {
        public ApodDbContext(DbContextOptions<ApodDbContext> options) : base(options)
        {
        }

        internal DbSet<Apod> Apods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
