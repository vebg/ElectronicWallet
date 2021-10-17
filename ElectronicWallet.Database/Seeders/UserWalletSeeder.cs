using ElectronicWallet.Database.Entities;
using ElectronicWallet.Database.Seeders.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ElectronicWallet.Database.Seeders
{
    public class UserWalletSeeder : ISeeder
    {
        public void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ElectronicWalletContext(
            serviceProvider.GetRequiredService<DbContextOptions<ElectronicWalletContext>>()))
            {
                if (context.UsersWallets.Any()) return;

                context.UsersWallets.AddRange( new UserWallet[] {
                    CreateDefaultWallets(Guid.Parse("A2AED979-D0A6-4DE5-A8A9-50F6B1B8E41A"),
                    Guid.Parse("C25C298E-AD15-4DE7-9A15-B8A2B7C6923F"),
                    Guid.Parse("45D6ED41-EDB1-4219-AEAE-FE71E756DC33")),
                });

                context.SaveChanges();
            };
            
        }

        private UserWallet CreateDefaultWallets(Guid id, Guid walletId, Guid userId)
        {
            return new UserWallet
            {
                Id = id,
                WalletId = walletId,
                UserId = userId,
                IsActive = true
            };
        }

    
    }
}
