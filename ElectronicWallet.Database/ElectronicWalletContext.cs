using ElectronicWallet.Database.Entities;
using ElectronicWallet.Database.Seeders;
using ElectronicWallet.Database.Seeders.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ElectronicWallet.Database
{
    public class ElectronicWalletContext: DbContext
    {
        public ElectronicWalletContext(DbContextOptions<ElectronicWalletContext> options):base(options) { }


        #region Tables

        public DbSet<UserWallet> UsersWallets { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

    }
}
