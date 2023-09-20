using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.Configuration
{
    public class AmbitsToTypesConfiguration : IEntityTypeConfiguration<AmbitsToTypes>
    {
        public void Configure(EntityTypeBuilder<AmbitsToTypes> builder)
        {
            builder.HasKey(x => new { x.AmbitId, x.TypeId });

            builder.HasOne(x => x.IncidentAmbit)
                .WithMany(x => x.AmbitsToTypes)
                .HasForeignKey(x => x.AmbitId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.IncidentType)
                .WithMany(x => x.AmbitsToTypes)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                IncidentsDbContextSeed.AmbitsToTypes1,
                IncidentsDbContextSeed.AmbitsToTypes2,
                IncidentsDbContextSeed.AmbitsToTypes3,
                IncidentsDbContextSeed.AmbitsToTypes4,
                IncidentsDbContextSeed.AmbitsToTypes5,
                IncidentsDbContextSeed.AmbitsToTypes6,
                IncidentsDbContextSeed.AmbitsToTypes7,
                IncidentsDbContextSeed.AmbitsToTypes8,
                IncidentsDbContextSeed.AmbitsToTypes9,
                IncidentsDbContextSeed.AmbitsToTypes10,
                IncidentsDbContextSeed.AmbitsToTypes11,
                IncidentsDbContextSeed.AmbitsToTypes12,
                IncidentsDbContextSeed.AmbitsToTypes13,
                IncidentsDbContextSeed.AmbitsToTypes14,
                IncidentsDbContextSeed.AmbitsToTypes15,
                IncidentsDbContextSeed.AmbitsToTypes16,
                IncidentsDbContextSeed.AmbitsToTypes17,
                IncidentsDbContextSeed.AmbitsToTypes18,
                IncidentsDbContextSeed.AmbitsToTypes19,
                IncidentsDbContextSeed.AmbitsToTypes20,
                IncidentsDbContextSeed.AmbitsToTypes21,
                IncidentsDbContextSeed.AmbitsToTypes22,
                IncidentsDbContextSeed.AmbitsToTypes23,
                IncidentsDbContextSeed.AmbitsToTypes24,
                IncidentsDbContextSeed.AmbitsToTypes25,
                IncidentsDbContextSeed.AmbitsToTypes26,
                IncidentsDbContextSeed.AmbitsToTypes27,
                IncidentsDbContextSeed.AmbitsToTypes28,
                IncidentsDbContextSeed.AmbitsToTypes29,
                IncidentsDbContextSeed.AmbitsToTypes30,
                IncidentsDbContextSeed.AmbitsToTypes31,
                IncidentsDbContextSeed.AmbitsToTypes32,
                IncidentsDbContextSeed.AmbitsToTypes33,
                IncidentsDbContextSeed.AmbitsToTypes34,
                IncidentsDbContextSeed.AmbitsToTypes35,
                IncidentsDbContextSeed.AmbitsToTypes36,
                IncidentsDbContextSeed.AmbitsToTypes37,
                IncidentsDbContextSeed.AmbitsToTypes38,
                IncidentsDbContextSeed.AmbitsToTypes39,
                IncidentsDbContextSeed.AmbitsToTypes40,
                IncidentsDbContextSeed.AmbitsToTypes41,
                IncidentsDbContextSeed.AmbitsToTypes42,
                IncidentsDbContextSeed.AmbitsToTypes43,
                IncidentsDbContextSeed.AmbitsToTypes44,
                IncidentsDbContextSeed.AmbitsToTypes45,
                IncidentsDbContextSeed.AmbitsToTypes46
                );
        }
    }
}
