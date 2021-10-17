using ElectronicWallet.Database.Entities;
using ElectronicWallet.Database.Seeders.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ElectronicWallet.Database.Seeders
{
    public class WalletSeeder : ISeeder
    {
        public void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ElectronicWalletContext(
            serviceProvider.GetRequiredService<DbContextOptions<ElectronicWalletContext>>()))
            {
                if (context.Wallets.Any()) return;

                context.Wallets.AddRange( new Wallet[] {
                    CreateDefaultWallets(Guid.Parse("45D6ED41-EDB1-4219-AEAE-FE71E756DC33"), "SavingHouse", Guid.Parse("9817AB27-EDFC-4949-A897-79A928F4774F"),1000),
                });

                context.SaveChanges();
            };
            
        }

        private Wallet CreateDefaultWallets(Guid id, string name, Guid currencyId, decimal balance)
        {
            return new Wallet
            {
                Id = id,
                Name = name,
                CurrencyId = currencyId,
                Balance = balance,
                IsActive = true
            };
        }

    
    }
}
