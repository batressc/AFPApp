using AFPApp.BusinessLogic.Implements;
using AFPApp.BusinessLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ConfigureServicesBusinessLogic {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration conf) {
            services.AddDataAccessLayer(conf);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IAfiliadoBusinessLogic, AfiliadoBusinessLogic>();
            return services;
        }
    }
}
