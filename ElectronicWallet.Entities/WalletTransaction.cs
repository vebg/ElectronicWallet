using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities
{
    public class WalletTransaction: EntityBase
    {
        public Guid Id { get; set; }
        public Guid ToWalletId { get; set; }
        public Guid FromWalletId { get; set; }
        public decimal Amount { get; set; }
        public bool IsProccessing { get; set; }
        public decimal Fee { get; set; }


        #region Relations

        public Wallet Wallet { get; set; }

        #endregion

    }
}
