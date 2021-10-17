using ElectronicWallet.Database;
using ElectronicWallet.Infraestructure.Installers;
using ElectronicWallet.Infraestructure.Installers.Contracts;
using ElectronicWallet.Infraestructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace ElectronicWallet.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var apiInstallers = typeof(DataInstaller).Assembly.ExportedTypes.Where(x =>
                    typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                    typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            apiInstallers.ForEach(installer => installer.InstallServices(services, Configuration));
            installers.ForEach(installer => installer.InstallServices(services, Configuration));

            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpSecurityHeaderMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsOptions");
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1");
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
