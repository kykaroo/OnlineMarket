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

    public void AddItem(Product product, int count)
    {
        ArgumentNullException.ThrowIfNull(product);

        var item = _items.SingleOrDefault(x => x.ProductId == product.Id);

        if (item == null)
        {
            _items.Add(new OrderItem(product.Id, count, product.Price));
        }
        else
        {
            _items.Remove(item);
            _items.Add(new OrderItem(product.Id,  item.Count + count, product.Price));
        }
    }
}
