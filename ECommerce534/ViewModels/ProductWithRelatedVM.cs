namespace ECommerce534.ViewModels;

public class ProductWithRelatedVM
{
    public Product Product { get; set; } = null!;
    public IEnumerable<Product> RelatedProductsByName { get; set; } = [];
    public IEnumerable<Product> RelatedProductsByCategoryName { get; set; } = [];
}
