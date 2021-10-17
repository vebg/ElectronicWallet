using System;

namespace ElectronicWallet.Database.DTO.Request
{
    public class WalletRequest
    {
        public Guid CurrencyId { get; set; }
        public string Name { get; set; }
    }
}
