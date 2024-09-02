using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ResetPasswordConfiguration : IEntityTypeConfiguration<ResetPassword>
    {
        public void Configure(EntityTypeBuilder<ResetPassword> builder)
        {
            // Tablo adı
            builder.ToTable("ResetPasswords");

            // Birincil anahtar
            builder.HasKey(p => p.Id);

            // Sütunlar
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.Ip)
                .IsRequired(false);

            builder.Property(p => p.ResetCode)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(p => p.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.LastModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.ExpiryDate)
                .IsRequired(false);
        }
    }
}
