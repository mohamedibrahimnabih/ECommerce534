namespace ECommerce534.ViewModels;

public class ProductRequestVM
{
    public string? Q { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? CategoryId { get; set; }
    public int? BrandId { get; set; }
}
