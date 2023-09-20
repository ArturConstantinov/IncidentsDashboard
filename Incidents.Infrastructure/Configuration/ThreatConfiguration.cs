using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.Configuration
{
    public class ThreatConfiguration : IEntityTypeConfiguration<Threat>
    {
        public void Configure(EntityTypeBuilder<Threat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(IncidentsDbContextSeed.ThreatAA1,
                IncidentsDbContextSeed.ThreatAA2,
                IncidentsDbContextSeed.ThreatAA3);
        }
    }
}
