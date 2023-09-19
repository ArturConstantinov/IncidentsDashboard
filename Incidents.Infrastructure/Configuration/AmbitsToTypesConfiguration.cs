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
        }
    }
}
