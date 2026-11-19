namespace ECommerce534.ViewModels;

public class CategoryWithFilterVM
{
    public IEnumerable<Category> Categories { get; set; } = [];
    public string? Q { get; set; }
    public double TotalPages { get; set; }
    public int CurrentPage { get; set; }
}
