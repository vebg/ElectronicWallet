using ElectronicWallet.Database;
using ElectronicWallet.Database.Entities;

using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
