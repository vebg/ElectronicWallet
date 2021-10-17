using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities.DTO
{
    public class WalletDto
    {
        public Guid Id { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        

    }
}
