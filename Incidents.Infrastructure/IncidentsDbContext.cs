using Incidents.Application.Common.Interfaces;
using Incidents.Domain.Common;
using Incidents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Incidents.Infrastructure
{
    public class IncidentsDbContext : DbContext, IIncidentsDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentType> IncidentTypes { get; set; }
        public DbSet<Ambit> Ambits { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Scenary> Scenarios { get; set; }
        public DbSet<Threat> Threats { get; set; }


        public IncidentsDbContext(DbContextOptions<IncidentsDbContext> options, ICurrentUserService currentUserService, IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
