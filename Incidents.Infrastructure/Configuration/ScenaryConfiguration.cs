using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.Configuration
{
    public class ScenaryConfiguration : IEntityTypeConfiguration<Scenary>
    {
        public void Configure(EntityTypeBuilder<Scenary> builder)
        {
            //builder.HasKey(x => x.Id)
            //    .IsClustered(false);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(IncidentsDbContextSeed.ScenaryA1,
                IncidentsDbContextSeed.ScenaryA2,
                IncidentsDbContextSeed.ScenaryA3);
        }
    }
}
