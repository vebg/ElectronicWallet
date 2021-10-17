using ElectronicWallet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicWallet.Database.EntitiesConfigurations
{
    public class WalletEntityConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Balance)
                .HasMaxLength(4)
                .IsRequired(); 

            builder.Property(e => e.IsActive)
                 .HasDefaultValue(true)
                 .IsRequired();

            builder.Property(e => e.IsDeleted)
                 .HasDefaultValue(false)
                 .IsRequired();

            builder.HasOne(e => e.Currency)
                .WithMany(user => user.Wallets)
                .HasForeignKey(entity => entity.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade);

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
