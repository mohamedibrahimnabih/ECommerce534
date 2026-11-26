namespace ECommerce534.ViewModels;

public class CreateProductResponseVM
{
    public IEnumerable<Category> Categories { get; set; } = [];
    public IEnumerable<Brand> Brands { get; set; } = [];
}
