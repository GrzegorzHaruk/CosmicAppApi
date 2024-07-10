using CosmicApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CosmicApp.Infrastructure.Persistance
{
    internal class ApodDbContext : IdentityDbContext<User>
    {
        public ApodDbContext(DbContextOptions<ApodDbContext> options) : base(options)
        {
        }

        internal DbSet<Apod> Apods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.OwnedApods)
            //    .WithOne(x => x.Owner)
            //    .HasForeignKey(x=>x.OwnerId);
        }
    }
}
