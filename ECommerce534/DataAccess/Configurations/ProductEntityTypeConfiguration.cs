using ECommerce534.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce534.DataAccess.Configurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .HasMaxLength(2000);

        builder.Property(p => p.MainImg)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.Property(p => p.Discount)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValue(0);

        builder.Property(p => p.Quantity)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(p => p.Traffic)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(p => p.Rate)
            .HasDefaultValue(0);

        builder.Property(p => p.Status)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(p => p.Brand)
            .WithMany()
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
