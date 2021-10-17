using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;

namespace ElectronicWallet.Services.Contracts
{
    public interface IWalletTransactionService: IManagementServiceBase<WalletTransactionDto, WalletTransaction>
    {
    }
}
