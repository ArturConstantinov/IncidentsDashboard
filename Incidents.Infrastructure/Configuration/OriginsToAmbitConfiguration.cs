using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.Configuration
{
    public class OriginsToAmbitConfiguration : IEntityTypeConfiguration<OriginsToAmbit>
    {
        public void Configure(EntityTypeBuilder<OriginsToAmbit> builder)
        {
            builder.HasKey(x => new { x.OriginId, x.AmbitId });

            builder.HasOne(x => x.Origin)
                .WithMany(x => x.OriginsToAmbits)
                .HasForeignKey(x => x.OriginId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Ambit)
                .WithMany(x => x.OriginsToAmbits)
                .HasForeignKey(x => x.AmbitId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                IncidentsDbContextSeed.OriginsToAmbit1,
                IncidentsDbContextSeed.OriginsToAmbit2,
                IncidentsDbContextSeed.OriginsToAmbit3,
                IncidentsDbContextSeed.OriginsToAmbit4,
                IncidentsDbContextSeed.OriginsToAmbit5,
                IncidentsDbContextSeed.OriginsToAmbit6,
                IncidentsDbContextSeed.OriginsToAmbit7,
                IncidentsDbContextSeed.OriginsToAmbit8,
                IncidentsDbContextSeed.OriginsToAmbit9,
                IncidentsDbContextSeed.OriginsToAmbit10,
                IncidentsDbContextSeed.OriginsToAmbit11,
                IncidentsDbContextSeed.OriginsToAmbit12,
                IncidentsDbContextSeed.OriginsToAmbit13,
                IncidentsDbContextSeed.OriginsToAmbit14,
                IncidentsDbContextSeed.OriginsToAmbit15,
                IncidentsDbContextSeed.OriginsToAmbit16,
                IncidentsDbContextSeed.OriginsToAmbit17,
                IncidentsDbContextSeed.OriginsToAmbit18,
                IncidentsDbContextSeed.OriginsToAmbit19,
                IncidentsDbContextSeed.OriginsToAmbit20,
                IncidentsDbContextSeed.OriginsToAmbit21
                );
        }
    }
}
