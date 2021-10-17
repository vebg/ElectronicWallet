using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities
{
    public class Payment : EntityBase
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }


        #region Relations

        public Wallet Wallet { get; set; }
        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}
