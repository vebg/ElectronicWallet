using System;
using System.Collections.Generic;

namespace ElectronicWallet.Database.DTO
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }

        #region Relations

        public WalletDto Wallet { get; set; }
        public ICollection<OrderDto> Orders { get; set; }

        #endregion
    }
}
