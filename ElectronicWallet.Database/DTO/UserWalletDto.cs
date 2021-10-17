using System;

namespace ElectronicWallet.Database.DTO
{
    public class UserWalletDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid WalletId { get; set; }
        public bool IsActive { get; set; }
        #region Relations

        public UserDto User { get; set; }
        public WalletDto Wallet { get; set; }


        #endregion

    }
}
