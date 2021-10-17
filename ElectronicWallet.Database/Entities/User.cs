using System;
using System.Collections.Generic;

namespace ElectronicWallet.Database.Entities
{
    public class User :EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string Password { get; set; }
        public DateTime? TokenExpirationDate { get; set; }
        public bool IsActive { get; set; }

        #region Relations

        public ICollection<UserWallet> UserWallets { get; set; }

        #endregion
    }
}
