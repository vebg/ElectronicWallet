using System;

namespace ElectronicWallet.Entities.DTO
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
