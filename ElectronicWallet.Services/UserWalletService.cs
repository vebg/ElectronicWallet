using AutoMapper;
using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class UserWalletService: ManegementServiceBase<UserWalletDto, UserWallet>, IUserWalletService
    {
        public UserWalletService(IUserWalletRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
