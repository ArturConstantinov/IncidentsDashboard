using Incidents.Application.Common.Interfaces;
using Incidents.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Incidents.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IncidentsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(IncidentsDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IIncidentsDbContext, IncidentsDbContext>();
            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
