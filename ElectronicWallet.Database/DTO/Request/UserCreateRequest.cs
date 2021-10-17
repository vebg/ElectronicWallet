namespace ElectronicWallet.Database.DTO.Request
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
