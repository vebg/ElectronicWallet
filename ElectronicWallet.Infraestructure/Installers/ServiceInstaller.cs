using ElectronicWallet.Infraestructure.Installers.Contracts;
using ElectronicWallet.Services;
using ElectronicWallet.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicWallet.Infraestructure.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IUserWalletService, UserWalletService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IWalletTransactionService, WalletTransactionService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
