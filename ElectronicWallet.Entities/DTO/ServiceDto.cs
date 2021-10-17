using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities.DTO
{
    public class ServiceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        
    }
}
