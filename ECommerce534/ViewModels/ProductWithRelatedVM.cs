namespace ECommerce534.ViewModels;

public class ProductWithRelatedVM
{
    public Product Product { get; set; } = null!;
    public IEnumerable<ProductColor> ProductColors { get; set; } = [];
    public IEnumerable<ProductSubImg> ProductSubImgs { get; set; } = [];
    public IEnumerable<Product> RelatedProductsByName { get; set; } = [];
    public IEnumerable<Product> RelatedProductsByCategoryName { get; set; } = [];
}
