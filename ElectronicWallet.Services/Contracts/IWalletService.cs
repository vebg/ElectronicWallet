using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;

namespace ElectronicWallet.Services.Contracts
{
    public interface IWalletService: IManagementServiceBase<WalletDto, Wallet>
    {
    }
}
