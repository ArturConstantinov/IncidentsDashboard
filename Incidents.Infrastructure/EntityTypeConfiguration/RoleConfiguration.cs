using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.EntityTypeConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id)
                .IsClustered(false);

            builder.Property(role => role.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(role => role.Name)
                .IsClustered(true)
                .IsUnique();

            builder.HasData(IncidentsDbContextSeed.AdminRole, IncidentsDbContextSeed.OperatorRole, IncidentsDbContextSeed.UserRole);
        }
    }
}
