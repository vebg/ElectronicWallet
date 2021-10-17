
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Database;
using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
