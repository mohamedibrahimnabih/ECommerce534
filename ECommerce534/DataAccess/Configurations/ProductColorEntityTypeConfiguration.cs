using ECommerce534.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce534.DataAccess.Configurations;

public class ProductColorEntityTypeConfiguration : IEntityTypeConfiguration<ProductColor>
{
    public void Configure(EntityTypeBuilder<ProductColor> builder)
    {
        builder.HasKey(pc => pc.Id);

        builder.Property(pc => pc.Color)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(pc => pc.Product)
            .WithMany()
            .HasForeignKey(pc => pc.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
