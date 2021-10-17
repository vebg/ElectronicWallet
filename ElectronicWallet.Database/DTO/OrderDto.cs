using System;

namespace ElectronicWallet.Database.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public Guid ServiceId { get; set; }
        public string OrderNumber { get; set; }
        #region Relations

        public PaymentDto Payment { get; set; }
        public ServiceDto Service { get; set; }

        #endregion

    }
}
