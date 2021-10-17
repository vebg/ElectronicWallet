using System;
using System.Collections.Generic;

namespace ElectronicWallet.Entities
{
    public class Order:EntityBase
    {
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public Guid ServiceId { get; set; }
        public string OrderNumber { get; set; }

        #region Relations

        public Payment Payment { get; set; }
        public Service Service { get; set; }

        #endregion


    }
}
