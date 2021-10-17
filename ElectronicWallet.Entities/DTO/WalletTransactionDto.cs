using System;

namespace ElectronicWallet.Entities.DTO
{
    public class WalletTransactionDto
    {
        public Guid Id { get; set; }
        public Guid ToWalletId { get; set; }
        public Guid FromWalletId { get; set; }
        public decimal Amount { get; set; }
        public bool IsProccessing { get; set; }
        public decimal Fee { get; set; }

    }
}
