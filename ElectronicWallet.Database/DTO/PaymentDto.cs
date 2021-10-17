﻿using System;

namespace ElectronicWallet.Database.DTO
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }        
    }
}
