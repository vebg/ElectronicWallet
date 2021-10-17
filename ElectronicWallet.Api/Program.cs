using ElectronicWallet.Database;
using ElectronicWallet.Database.Seeders;
using ElectronicWallet.Database.Seeders.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace ElectronicWallet.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //1 Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                //2 Get the instance of ElectronicWalletContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ElectronicWalletContext>();

                //3 Call the Seed to create sample data
                var seeders = new List<ISeeder>{
                    new UserSeeder(),
                    new WalletSeeder(),
                    new UserWalletSeeder()
                };

                foreach (var seeder in seeders)
                {
                    seeder.Seed(services);
                }

            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
