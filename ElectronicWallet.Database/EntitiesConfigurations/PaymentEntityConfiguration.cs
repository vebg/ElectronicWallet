using ElectronicWallet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicWallet.Database.EntitiesConfigurations
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Wallet)
                .WithMany(user => user.Payments)
                .HasForeignKey(entity => entity.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Fee)
                 .HasDefaultValue(0)
                 .IsRequired();

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
