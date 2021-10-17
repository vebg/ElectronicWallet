using ElectronicWallet.Infraestructure.Installers.Contracts;
using ElectronicWallet.Infraestructure.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicWallet.Infraestructure
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddMvcCore(options =>
            {
                options.Filters.Add(typeof(ExceptionHandler));
                options.Filters.Add(typeof(ValidateModel));

            });

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
        }
    }
}
