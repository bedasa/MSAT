namespace Com.MSAT.Infrastructure.Models;

public class OrderLine : Entity
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    
    public required Order ParentOrder { get; set; }
    public required Product ProductItem { get; set; }
}