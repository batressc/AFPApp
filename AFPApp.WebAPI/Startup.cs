using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;

namespace AFPApp.WebAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddBusinessLogicLayer(Configuration);
            services.AddControllers().AddFluentValidation();
            // Agregando Swagger
            OpenApiInfo info = new OpenApiInfo() {
                Title = "AFP API for Afiliados",
                Version = "V1",
                Description = "API for CRUD operations for Afiliados"
            };
            services.AddSwaggerGen(conf => {
                conf.SwaggerDoc("v1", info);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseBusinessLogicLayer(env, Configuration);
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(conf => {
                conf.SwaggerEndpoint($"/swagger/v1/swagger.json", "AFPApp");
            });
        }
    }
}
