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
                .IsClustered(true);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                IncidentsDbContextSeed.ConfigurationPhA,
                IncidentsDbContextSeed.SoftwareMalfunctionPhA,
                IncidentsDbContextSeed.ConfigurationPhI,
                IncidentsDbContextSeed.SoftwareMalfunctionPhI,
                IncidentsDbContextSeed.SoftwareMalfunctionFunA,
                IncidentsDbContextSeed.ThirdPartsFunE,
                IncidentsDbContextSeed.IncorrectChangeRelA,
                IncidentsDbContextSeed.IncorrectChangeSoftA,
                IncidentsDbContextSeed.Code,
                IncidentsDbContextSeed.ConfigurationSoftA,
                IncidentsDbContextSeed.ResourceSaturationSoftA,
                IncidentsDbContextSeed.ThirdPartsSoftE,
                IncidentsDbContextSeed.InsufficientResourcesSoftI,
                IncidentsDbContextSeed.ThirdPartsServ,
                IncidentsDbContextSeed.SoftwareMalfunctionTransCh,
                IncidentsDbContextSeed.InsufficientResourcesTransCh,
                IncidentsDbContextSeed.ConfigurationTransCh,
                IncidentsDbContextSeed.HardwareMalfunctionCICS,
                IncidentsDbContextSeed.ConfigurationCICS,
                IncidentsDbContextSeed.DegradationDB,
                IncidentsDbContextSeed.HardwareMalfunctionDB,
                IncidentsDbContextSeed.SoftwareMalfunctionDB,
                IncidentsDbContextSeed.InsufficientResourcesDB,
                IncidentsDbContextSeed.InsufficientResourcesHardHost,
                IncidentsDbContextSeed.ResourceSaturationHardHost,
                IncidentsDbContextSeed.IncorrectChangeHardOpen,
                IncidentsDbContextSeed.BlockHardOpen,
                IncidentsDbContextSeed.DegradationHardOpen,
                IncidentsDbContextSeed.InsufficientResourcesHardOpen,
                IncidentsDbContextSeed.IncorrectChangeMiddl,
                IncidentsDbContextSeed.SoftwareMalfunctionMiddl,
                IncidentsDbContextSeed.InsufficientResourcesMiddl,
                IncidentsDbContextSeed.ResourceSaturationMiddl,
                IncidentsDbContextSeed.IncorrectChangeNet,
                IncidentsDbContextSeed.Accesses,
                IncidentsDbContextSeed.CyberAttacks,
                IncidentsDbContextSeed.Certificates,
                IncidentsDbContextSeed.ConfigurationSec,
                IncidentsDbContextSeed.Firewall,
                IncidentsDbContextSeed.IDM,
                IncidentsDbContextSeed.Patching,
                IncidentsDbContextSeed.InsufficientResourcesBHS,
                IncidentsDbContextSeed.InsufficientResourcesOBS,
                IncidentsDbContextSeed.ResourceSaturationOBS,
                IncidentsDbContextSeed.BlockServSoft,
                IncidentsDbContextSeed.DegradationServSoft,
                IncidentsDbContextSeed.ResourceSaturationServSoft,
                IncidentsDbContextSeed.ResourceSaturationStor
                );
        }
    }
}
