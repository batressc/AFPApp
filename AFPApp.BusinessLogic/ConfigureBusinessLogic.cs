using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder {
    public static class ConfigureBusinessLogic {
        public static IApplicationBuilder UseBusinessLogicLayer(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration conf) {
            app.UseDataAccessLayer(env, conf);
            return app;
        }
    }
}
