using System;

namespace ElectronicWallet.Database.DTO
{
    public class WalletTransactionDto
    {
        public Guid Id { get; set; }
        public Guid ToWalletId { get; set; }
        public Guid FromWalletId { get; set; }
        public decimal Amount { get; set; }
        public bool IsProccessing { get; set; }
        public decimal Fee { get; set; }
        #region Relations

        public WalletDto Wallet { get; set; }

        #endregion
    }
}
