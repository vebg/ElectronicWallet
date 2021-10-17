using AutoMapper;
using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class WalletTransactionService : ManegementServiceBase<WalletTransactionDto, WalletTransaction>, IWalletTransactionService
    {
        public WalletTransactionService(IWalletTransactionRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
