using ElectronicWallet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicWallet.Database.EntitiesConfigurations
{
    public class WalletTransactionEntityConfiguration : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Wallet)
                .WithMany(user => user.WalletTransactions)
                .HasForeignKey(entity => entity.ToWalletId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(e => e.Wallet)
                .WithMany(user => user.WalletTransactions)
                .HasForeignKey(entity => entity.FromWalletId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Amount)
                .IsRequired(); 

            builder.Property(e => e.IsProccessing)
                 .HasDefaultValue(true)
                 .IsRequired();

            builder.Property(e => e.Fee)
                 .HasDefaultValue(0)
                 .IsRequired(true);

            #region Audition

            builder.Property(e => e.CreatedBy)
                .IsRequired(); 
            
            builder.Property(e => e.UpdatedAt)
                .IsRequired(false);
            
            builder.Property(e => e.CreatedAt)
                .HasDefaultValue(new System.DateTime())
                .IsRequired(true);

            builder.Property(e => e.ModifiedBy)
                .IsRequired();
            #endregion




        }
    }
}
