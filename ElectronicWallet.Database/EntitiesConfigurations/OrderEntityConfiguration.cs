using ElectronicWallet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicWallet.Database.EntitiesConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Payment)
                .WithMany(user => user.Orders)
                .HasForeignKey(entity => entity.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Service)
               .WithMany(user => user.Orders)
               .HasForeignKey(entity => entity.ServiceId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.OrderNumber)
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
