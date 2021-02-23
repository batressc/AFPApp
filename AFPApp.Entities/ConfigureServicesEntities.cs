using FluentValidation;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ConfigureServicesEntities {
        public static IServiceCollection AddEntitiesLayer(this IServiceCollection services, IConfiguration conf) {
            _ = conf;
            // Agregando validators definidos en este ensamblado
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}