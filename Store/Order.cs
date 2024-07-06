namespace Store;

public class Order
{
    public int Id { get; }
    
    public IReadOnlyCollection<OrderItem> Items => _items;

    public int TotalCount => _items.Sum(item => item.Count);
    public float TotalPrice => _items.Sum(item => item.Price * item.Count);
    
    private readonly List<OrderItem> _items;

    public Order(int id, IEnumerable<OrderItem> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        Id = id;
        
        _items = [..items];
    }

    public void AddItem(Item? item, int count)
    {
        ArgumentNullException.ThrowIfNull(item);

        var itemFromList = _items.SingleOrDefault(x => x.ProductId == item.Id);

        switch (itemFromList)
        {
            case null:
                _items.Add(new OrderItem(item.Id, count, item.Price));
                break;
            default:
                _items.First(x => x == itemFromList).Count += count;
                break;
        }
    }
}
