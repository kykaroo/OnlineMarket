namespace Store;

public class Order
{
    public int Id { get; }
    
    public OrderItemCollection Items { get; }

    public int TotalCount => Items.Sum(item => item.Count);
    public float TotalPrice => Items.Sum(item => item.Price * item.Count);

    public Order(int id, IEnumerable<OrderItem> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        Id = id;
        
        Items = new OrderItemCollection(items);
    }
}
