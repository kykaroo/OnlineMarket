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

    public void AddItems(Item item, int count)
    {
        var errorMessage = string.Empty;
        
        var orderItem = GetItem(item, ref errorMessage);

        if (orderItem == null)
        {
            _items.Add(new OrderItem(item.Id, count, item.Price));
            return;
        }
        
        orderItem.Count += count;
    }

    public bool TryRemoveAllItems(Item item, out string errorMessage)
    { 
        errorMessage = string.Empty; 
        
        var orderItem = GetItem(item, ref errorMessage);
        
        if (orderItem == null) return false;

        _items.Remove(orderItem);
        return true;
    }

    public bool TryRemoveItems(Item item, int count, out string errorMessage)
    {
        errorMessage = string.Empty;

        var orderItem = GetItem(item, ref errorMessage);
        
        if (orderItem == null) return false;

        if (orderItem.Count <= count)
        {
            _items.Remove(orderItem);
            return true;
        }
        
        orderItem.Count -= count;
        
        return true;
    }

    private OrderItem? GetItem(Item item, ref string errorMessage)
    {
        var index = _items.FindIndex(x => x.ItemId == item.Id);

        if (index != -1) return _items[index];
        
        errorMessage = $"Item with ID \"{item.Id}\" not ordered yet";
        return null;

    }
}
