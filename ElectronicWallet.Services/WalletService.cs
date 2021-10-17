using AutoMapper;
using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class WalletService: ManegementServiceBase<WalletDto, Wallet>, IWalletService
    {
        public WalletService(IWalletRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
