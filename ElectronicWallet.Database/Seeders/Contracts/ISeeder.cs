using System;

namespace ElectronicWallet.Database.Seeders.Contracts
{
    public interface ISeeder
    {
        public void Seed(IServiceProvider serviceProvider);
    }
}
