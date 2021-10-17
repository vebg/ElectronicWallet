using ElectronicWallet.Database;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class ServiceRepository: RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
