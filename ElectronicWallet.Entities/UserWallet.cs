using System;

namespace ElectronicWallet.Entities
{
    public class UserWallet: EntityBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid WalletID { get; set; }
        public bool IsActive { get; set; }

        #region Relations

        public User User { get; set; }
        public Wallet Wallet { get; set; }


        #endregion
    }
}
