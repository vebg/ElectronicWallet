using System;

namespace ElectronicWallet.Database.DTO.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
