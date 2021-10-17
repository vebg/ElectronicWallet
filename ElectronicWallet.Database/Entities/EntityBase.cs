using System;

namespace ElectronicWallet.Database.Entities
{
    public abstract class EntityBase
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
