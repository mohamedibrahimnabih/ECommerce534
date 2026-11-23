namespace ECommerce534.ViewModels;

public class BrandWithFilterVM
{
    public IEnumerable<Brand> Brands { get; set; } = [];
    public string? Q { get; set; }
    public double TotalPages { get; set; }
    public int CurrentPage { get; set; }
}
