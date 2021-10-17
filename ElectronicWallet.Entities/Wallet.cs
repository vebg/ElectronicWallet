using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities
{
    public class Wallet: EntityBase
    {
        public Guid Id { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations

        public ICollection<Payment> Payments { get; set; }
        public ICollection<UserWallet> UsersWallets { get; set; }
        public ICollection<WalletTransaction> WalletTransactions { get; set; }

        public Currency Currency { get; set; }
        #endregion

    }
}
