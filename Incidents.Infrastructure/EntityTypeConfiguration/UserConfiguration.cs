using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incidents.Infrastructure.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.UserName)
                .HasMaxLength(7)
                .IsRequired();

            builder.HasIndex(user => user.UserName)
                .IsUnique();

            builder.Property(user => user.FullName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.Property(user => user.IsEnabled)
                .HasDefaultValue(true);

            builder.Property(user => user.IsDeleted)
                .HasDefaultValue(false);

            builder.HasData(IncidentsDbContextSeed.Admin, IncidentsDbContextSeed.User);
        }
    }
}
