namespace xpe.Models;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? Sku { get; set; }
    public bool Active { get; set; }
}