using AFPApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ConfigureServicesDataAccess {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration conf) {
            services.AddEntitiesLayer(conf);
            services.AddDbContext<AFPAppDbContext>(options => {
                options.UseSqlServer(conf.GetConnectionString("AFPAppDbConnection"), opt => {
                    opt.EnableRetryOnFailure();
                });
                options.EnableDetailedErrors(true);
                options.EnableSensitiveDataLogging(true);
            });
            // Agregando interfaces de repositorio
            //services.DiscoverAndRegisterRepositories(Assembly.GetExecutingAssembly(), typeof(IRepository<,>));
            return services;
        }
    }
}