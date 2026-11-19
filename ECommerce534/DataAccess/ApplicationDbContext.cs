using ECommerce534.DataAccess.Configurations;
using ECommerce534.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ECommerce534.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ProductSubImg> ProductSubImgs { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Ecommerce534;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityTypeConfiguration).Assembly);
    }
}
