using System;

namespace ElectronicWallet.Database.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public DateTime? TokenExpirationDate { get; set; }
        public bool IsActive { get; set; }
    }

   
}
