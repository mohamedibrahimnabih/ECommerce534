namespace ECommerce534.ViewModels;

public class UpdateProductResponseVM
{
    public Product Product { get; set; } = null!;
    public IEnumerable<ProductSubImg> ProductSubImgs { get; set; } = [];
    public IEnumerable<ProductColor> ProductColors { get; set; } = [];
    public IEnumerable<Category> Categories { get; set; } = [];
    public IEnumerable<Brand> Brands { get; set; } = [];
}
