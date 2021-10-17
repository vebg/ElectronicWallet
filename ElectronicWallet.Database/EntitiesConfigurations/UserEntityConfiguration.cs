using ElectronicWallet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicWallet.Database.EntitiesConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsRequired(); 
            
            builder.Property(e => e.Gender)
                 .HasMaxLength(1)
                 .IsRequired(); 
            
            builder.Property(e => e.Email)
                 .HasMaxLength(255)
                 .IsRequired();
            
            builder.Property(e => e.AccessToken)
                 .HasMaxLength(int.MaxValue)
                 .IsRequired(false); 
            
            builder.Property(e => e.TokenExpirationDate)
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
