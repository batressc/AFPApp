using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder {
    public static class ConfigureDataAccess {
        public static IApplicationBuilder UseDataAccessLayer(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration conf) {
            app.UseEntitiesLayer(env, conf);
            return app;
        }
    }
}
