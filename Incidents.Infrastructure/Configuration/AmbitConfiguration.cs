using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.Configuration
{
    public class AmbitConfiguration : IEntityTypeConfiguration<Ambit>
    {
        public void Configure(EntityTypeBuilder<Ambit> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasIndex(x => x.Name)
                .IsClustered(true);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                IncidentsDbContextSeed.Software,
                IncidentsDbContextSeed.Functionality,
                IncidentsDbContextSeed.Phase,
                IncidentsDbContextSeed.Release,
                IncidentsDbContextSeed.Service,
                IncidentsDbContextSeed.TransmissionChannels,
                IncidentsDbContextSeed.CICS,
                IncidentsDbContextSeed.Database,
                IncidentsDbContextSeed.HardwareHost,
                IncidentsDbContextSeed.HardwareOpen,
                IncidentsDbContextSeed.Middleware,
                IncidentsDbContextSeed.Networks,
                IncidentsDbContextSeed.Security,
                IncidentsDbContextSeed.BasicHostSoftware,
                IncidentsDbContextSeed.OpenBasicSoftware,
                IncidentsDbContextSeed.ServiceSoftware,
                IncidentsDbContextSeed.Storage
                );
        }
    }
}
