using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Common.Interfaces
{
    public interface IIncidentsDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Incident> Incidents { get; set; }
        DbSet<IncidentType> IncidentTypes { get; set; }
        DbSet<Ambit> Ambits { get; set; }
        DbSet<Origin> Origins { get; set; }
        DbSet<Scenary> Scenarios { get; set; }
        DbSet<Threat> Threats { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
