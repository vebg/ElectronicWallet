﻿using System;

namespace ElectronicWallet.Database.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public Guid ServiceId { get; set; }
        public string OrderNumber { get; set; }    


    }
}
