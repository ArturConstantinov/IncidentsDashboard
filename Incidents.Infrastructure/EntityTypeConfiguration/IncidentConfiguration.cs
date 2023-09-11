using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.EntityTypeConfiguration
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestNr)
                .HasMaxLength(17)
                .IsRequired();

            builder.HasIndex(x => x.RequestNr)
                .IsUnique();

            builder.Property(x => x.Subsystem)
                .HasMaxLength(2);

            builder.Property(x => x.Type)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ApplicationType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Urgency)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.SubCause)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ProblemSummery)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ProblemDescription)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Solution)
                .HasMaxLength(250)
                .IsRequired();

            //builder.Property(x => x.IsEnabled)
            //    .HasDefaultValue(true);

            builder.HasData(IncidentsDbContextSeed.Incident);
            
        }
    }
}
