using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities
{
    public class User :EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public DateTime? TokenExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        #region Relations

        public ICollection<UserWallet> UserWallets { get; set; }

        #endregion
    }
}
