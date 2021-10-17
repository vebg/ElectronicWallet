using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicWallet.Services.Contracts
{
    public interface IUserWalletService : IManagementServiceBase<UserWalletDto, UserWallet>
    {
        public Task<GenericResponse<List<WalletDto>>> GetWalletsByUserId(Guid userId);
        public Task<GenericResponse<WalletDto>> GetWalletByUserIdAndWalletId(Guid userId, Guid walletId);

    }
}
