using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using System;
using System.Threading.Tasks;

namespace ElectronicWallet.Services.Contracts
{
    public interface IWalletService: IManagementServiceBase<WalletDto, Wallet>
    {
        public Task<GenericResponse> CreateAndAssingWallet(Guid userId,WalletDto request);
        public Task<GenericResponse> AddBalance(Guid userId, Guid walletId, decimal amount);

    }
}
