using System;

namespace ElectronicWallet.Database.DTO
{
    public class WalletDto
    {
        public Guid Id { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        #region Relations
        #endregion

    }
}
