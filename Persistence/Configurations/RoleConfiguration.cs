using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
     
            builder.HasKey(r => r.Id);

           
            builder.ToTable("Roles");

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256); 

            builder.Property(r => r.Description)
                .HasMaxLength(500); 
        }
    }
}
