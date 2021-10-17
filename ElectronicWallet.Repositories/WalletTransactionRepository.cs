using ElectronicWallet.Database;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class WalletTransactionRepository : RepositoryBase<WalletTransaction>, IWalletTransactionRepository
    {
        public WalletTransactionRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
