namespace Com.MSAT.Domain.Models;

public sealed class Product : Entity
{
    public string ProductName { get; set; } = string.Empty;
    public long CategoryId { get; set; }
    public float Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime DateAdded { get; set; }
    public required Category ProductCategory { get; set; }
}