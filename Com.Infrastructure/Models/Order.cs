namespace Com.MSAT.Infrastructure.Models;

public class Order : Entity
{
    private readonly List<OrderLine> _orderLines;

    public Order()
    {
        _orderLines = new List<OrderLine>();
    }

    public DateTime OrderDate { get; set; }
    public required string CustomerName { get; set; }

    public IList<OrderLine> OrderLines => _orderLines;

    public void AddOrderLines(IList<OrderLine> orderLines)
    {
        foreach (var t in orderLines)
        {
            AddOrderLine(t);
        }
    }

    private void AddOrderLine(OrderLine orderLine)
    {
        OrderLines.Add(orderLine);
    }
}