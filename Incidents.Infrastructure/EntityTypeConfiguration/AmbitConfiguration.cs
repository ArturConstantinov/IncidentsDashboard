using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.EntityTypeConfiguration
{
    public class AmbitConfiguration : IEntityTypeConfiguration<Ambit>
    {
        public void Configure(EntityTypeBuilder<Ambit> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);
            builder.HasIndex(x => x.Name)
                .IsClustered(true)
                .IsUnique();
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
