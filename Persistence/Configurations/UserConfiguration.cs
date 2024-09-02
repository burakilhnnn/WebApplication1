using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           
            builder.HasKey(u => u.Id);

            builder.ToTable("Users");

            
            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.RefreshToken)
                .HasMaxLength(500);

            builder.Property(u => u.RefreshTokenExpiryTime)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256); 

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(256);

            // Indexes
            builder.HasIndex(u => u.Email)
                .IsUnique();   
        }
    }
}
