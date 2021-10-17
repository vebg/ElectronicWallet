using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities
{
    public class Currency: EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations

        public ICollection<Wallet> Wallets { get; set; }

        #endregion

    }
}
