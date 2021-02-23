using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder {
    public static class ConfigureEntities {
        public static IApplicationBuilder UseEntitiesLayer(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration conf) {
            _ = env;
            _ = conf;
            return app;
        }
    }
}