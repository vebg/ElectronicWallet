using ElectronicWallet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicWallet.Database.EntitiesConfigurations
{
    public class UserWalletEntityConfiguration : IEntityTypeConfiguration<UserWallet>
    {
        public void Configure(EntityTypeBuilder<UserWallet> builder)
        {
            builder.HasKey(e => e.Id);


            builder.HasOne(e => e.User)
                .WithMany(user => user.UserWallets)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Wallet)
                .WithMany(user => user.UsersWallets)
                .HasForeignKey(entity => entity.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(e => e.IsActive)
                 .HasDefaultValue(true)
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
