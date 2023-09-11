using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace Incidents.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationt(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            return services;
        }
    }
}
