using System;
using System.Collections.Generic;

namespace ElectronicWallet.Database.DTO
{
    public class ServiceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations

        public ICollection<OrderDto> Orders { get; set; }

        #endregion
    }
}
