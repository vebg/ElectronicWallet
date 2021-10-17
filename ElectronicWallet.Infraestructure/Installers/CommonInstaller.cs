using ElectronicWallet.Common.Options;
using ElectronicWallet.Infraestructure.Installers.Contracts;
using ElectronicWallet.Infraestructure.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicWallet.Infraestructure.Installers
{
    public class CommonInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpSecurityHeaderMiddleware>();

            services.Configure<JwtOptions>(options =>
            {
                configuration.Bind("Authentication:Jwt", options);
            });
        }
    }
}
