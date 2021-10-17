using ElectronicWallet.Database.Entities;
using ElectronicWallet.Database.Seeders.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ElectronicWallet.Database.Seeders
{
    public class UserSeeder : ISeeder
    {
        public void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ElectronicWalletContext(
            serviceProvider.GetRequiredService<DbContextOptions<ElectronicWalletContext>>()))
            {
                if (context.Users.Any()) return;

                context.Users.AddRange( new User [] {
                    CreateDefaultUsers(Guid.Parse("C25C298E-AD15-4DE7-9A15-B8A2B7C6923F"), "Victor", "Brito", "M", "victor@gmail.com", "123456789"),
                    CreateDefaultUsers(Guid.Parse("E14FBA51-27D9-416E-86C6-5FB470AE4EA1"), "Solenny", "De Leon", "F", "sol@gmail.com", "123456789")
                });

                context.SaveChanges();
            };
            
        }

        private User CreateDefaultUsers(Guid id, string name, string lasname, string gender, string email, string password)
        {
            return new User
            {
                Id = id,
                Email = email,
                Name = name,
                LastName = lasname,
                Gender = gender,
                Password = password,
                IsActive = true
            };
        }

    
    }
}
