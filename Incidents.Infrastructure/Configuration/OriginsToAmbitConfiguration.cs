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
        }
    }
}
