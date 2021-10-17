using System;

namespace ElectronicWallet.Database.DTO
{
    public class UserWalletDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid WalletID { get; set; }
        public bool IsActive { get; set; }

        
    }
}
