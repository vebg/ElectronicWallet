using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;

namespace ElectronicWallet.Services.Contracts
{
    public interface IWalletTransactionService: IManagementServiceBase<WalletTransactionDto, WalletTransaction>
    {
    }
}
