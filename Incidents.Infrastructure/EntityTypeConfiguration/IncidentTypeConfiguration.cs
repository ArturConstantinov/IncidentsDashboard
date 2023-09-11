using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.EntityTypeConfiguration
{
    public class IncidentTypeConfiguration : IEntityTypeConfiguration<IncidentType>
    {
        public void Configure(EntityTypeBuilder<IncidentType> builder)
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
