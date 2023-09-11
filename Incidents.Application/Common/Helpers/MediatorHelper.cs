using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Incidents.Application.Common.Helpers
{
    public static class MediatorHelper
    {
        public static void AssemblyMediatRHelper(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var handlerTypes = assembly.GetTypes()
                .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();

            foreach (var handlerType in handlerTypes)
            {
                services.AddScoped(handlerType);
            }

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.Lifetime = ServiceLifetime.Scoped;
            });
        }
    }
}
