﻿using ElectronicWallet.Database;
using ElectronicWallet.Entities;
using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class UserWalletRepository: RepositoryBase<UserWallet>, IUserWalletRepository
    {
        public UserWalletRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
