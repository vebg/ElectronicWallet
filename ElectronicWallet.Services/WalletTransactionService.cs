using AutoMapper;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class WalletTransactionService : ManagementServiceBase<WalletTransactionDto, WalletTransaction>, IWalletTransactionService
    {
        public WalletTransactionService(IWalletTransactionRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
