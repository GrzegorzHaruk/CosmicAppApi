using CosmicApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmicApp.Infrastructure.Configurations
{
    public class ApodConfiguration : IEntityTypeConfiguration<Apod>
    {
        public void Configure(EntityTypeBuilder<Apod> builder)
        {
            builder
                .Property(x => x.Id)
                .IsRequired();

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .HasMaxLength(20);

            builder
                .Property(x=>x.Date)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(x => x.MediaType)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
