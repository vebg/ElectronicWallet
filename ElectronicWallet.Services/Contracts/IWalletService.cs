using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;


namespace ElectronicWallet.Services.Contracts
{
    public interface IWalletService: IManagementServiceBase<WalletDto, Wallet>
    {
    }
}
