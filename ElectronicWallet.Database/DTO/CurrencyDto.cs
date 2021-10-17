using System;
using System.Collections.Generic;

namespace ElectronicWallet.Database.DTO
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations

        public ICollection<WalletDto> Wallets { get; set; }

        #endregion

    }
}
