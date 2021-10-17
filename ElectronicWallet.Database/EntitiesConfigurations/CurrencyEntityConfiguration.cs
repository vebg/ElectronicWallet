using ElectronicWallet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicWallet.Database.EntitiesConfigurations
{
    public class CurrencyEntityConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Abbreviation)
                .HasMaxLength(4)
                .IsRequired(false); 

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
