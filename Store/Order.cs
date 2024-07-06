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

    public void AddItem(Item item, int count)
    {
        var itemFromList = _items.SingleOrDefault(x => x.ItemId == item.Id);

        switch (itemFromList)
        {
            case null:
                _items.Add(new OrderItem(item.Id, count, item.Price));
                break;
            default:
                itemFromList.Count += count;
                break;
        }
    }

    public bool TryRemoveItem(Item item, out string errorMessage)
    { 
        errorMessage = string.Empty; 
        var itemFromList = _items.SingleOrDefault(x => x.ItemId == item.Id);
        
        if (itemFromList == null)
        {
            errorMessage = $"Item with ID \"{item.Id}\" not ordered yet";
            return false;
        }

        _items.RemoveAll(x => x.ItemId == item.Id);
        return true;
    }
}
