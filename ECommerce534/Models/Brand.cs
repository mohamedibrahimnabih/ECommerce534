namespace ECommerce534.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public bool Status { get; set; } = true;
}
