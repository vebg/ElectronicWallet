using ElectronicWallet.Database;
using ElectronicWallet.Infraestructure.Installers.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicWallet.Infraestructure.Installers
{
    public class DataInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElectronicWalletContext>(options => options.UseInMemoryDatabase("ElectronicWallet"));
        }
    }
}
