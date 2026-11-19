using ECommerce534.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce534.DataAccess.Configurations;

public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(b => b.Logo)
            .HasMaxLength(500);

        builder.Property(b => b.Status)
            .IsRequired()
            .HasDefaultValue(true);
    }
}
