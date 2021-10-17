using System;
using System.Collections.Generic;

namespace ElectronicWallet.Database.Entities
{
    public class Service:EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations

        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}
