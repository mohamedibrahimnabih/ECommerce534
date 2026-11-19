using ECommerce534.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce534.DataAccess.Configurations;

public class ProductSubImgEntityTypeConfiguration : IEntityTypeConfiguration<ProductSubImg>
{
    public void Configure(EntityTypeBuilder<ProductSubImg> builder)
    {
        builder.HasKey(psi => psi.Id);

        builder.Property(psi => psi.SubImg)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(psi => psi.Product)
            .WithMany()
            .HasForeignKey(psi => psi.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
