namespace Store;

public class Order
{
    public int Id { get; }
    
    public IReadOnlyCollection<OrderItem> Items => _items;

    public int TotalCount => _items.Sum(item => item.Count);
    public float TotalPrice => _items.Sum(item => item.Price * item.Count);
    
    private List<OrderItem> _items;

    public Order(int id, IEnumerable<OrderItem> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        Id = id;
        
        _items = [..items];
    }
}
