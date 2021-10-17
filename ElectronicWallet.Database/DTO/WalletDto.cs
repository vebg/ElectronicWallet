using System;
using System.Collections.Generic;

namespace ElectronicWallet.Database.DTO
{
    public class WalletDto
    {
        public Guid Id { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations

        public ICollection<PaymentDto> Payments { get; set; }
        public ICollection<UserWalletDto> UsersWallets { get; set; }
        public ICollection<WalletTransactionDto> WalletTransactions { get; set; }

        public CurrencyDto Currency { get; set; }
        #endregion

    }
}
