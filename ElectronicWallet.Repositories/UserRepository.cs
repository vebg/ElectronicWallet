using ElectronicWallet.Database;
using ElectronicWallet.Entities;
using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
