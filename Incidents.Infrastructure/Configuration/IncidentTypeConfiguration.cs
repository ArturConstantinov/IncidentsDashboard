using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.Configuration
{
    public class IncidentTypeConfiguration : IEntityTypeConfiguration<IncidentType>
    {
        public void Configure(EntityTypeBuilder<IncidentType> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasIndex(x => x.Name)
                .IsClustered(true);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                IncidentsDbContextSeed.Configuration,
                IncidentsDbContextSeed.SoftwareMalfunction,
                IncidentsDbContextSeed.ThirdParts,
                IncidentsDbContextSeed.IncorrectChange,
                IncidentsDbContextSeed.Code,
                IncidentsDbContextSeed.ResourceSaturation,
                IncidentsDbContextSeed.InsufficientResources,
                IncidentsDbContextSeed.HardwareMalfunction,
                IncidentsDbContextSeed.Degradation,
                IncidentsDbContextSeed.Block,
                IncidentsDbContextSeed.Accesses,
                IncidentsDbContextSeed.CyberAttacks,
                IncidentsDbContextSeed.Certificates,
                IncidentsDbContextSeed.Firewall,
                IncidentsDbContextSeed.IDM,
                IncidentsDbContextSeed.Patching
                );
        }
    }
}
