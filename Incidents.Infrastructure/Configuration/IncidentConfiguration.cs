using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.Configuration
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
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.ProblemDescription)
                .HasMaxLength(350)
                .IsRequired();

            builder.Property(x => x.Solution)
                .HasMaxLength(350)
                .IsRequired();

            builder.Property(x => x.ThirdParty)
                .HasMaxLength(50);

            builder.HasOne(x => x.Scenary)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.ScenaryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Threat)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.ThreatId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Origin)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.OriginId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Ambit)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.AmbitId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.IncidentType)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.IncidentTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.OriginId)
                .IsRequired(false);

            builder.Property(x => x.AmbitId)
                .IsRequired(false);

            builder.Property(x => x.IncidentTypeId)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
