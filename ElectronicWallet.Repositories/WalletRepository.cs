using ElectronicWallet.Database;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class WalletRepository: RepositoryBase<Wallet>, IWalletRepository
    {
        public WalletRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
