namespace EcommerceBackend.Data.Models;

public class Product : IUniqueIdentifier
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Size { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal Price { get; set; }
    public string Designer { get; set; }
    public string ImageUrl { get; set; }
}