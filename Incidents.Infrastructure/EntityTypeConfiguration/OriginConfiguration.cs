using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.EntityTypeConfiguration
{
    public class OriginConfiguration : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
