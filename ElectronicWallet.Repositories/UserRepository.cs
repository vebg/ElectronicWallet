using ElectronicWallet.Database;
using ElectronicWallet.Database.Entities;
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
