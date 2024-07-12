using Store.Data;

namespace Store;

public class Order
{
    private readonly OrderData _order;
    public int Id => _order.Id;
    public string User => _order.UserName;
    public int TotalCount => Items.Sum(item => item.Count);
    public float TotalPrice => Items.Sum(item => item.Price * item.Count);
    public OrderItemCollection Items { get; }

    public Order(OrderData order)
    {
        _order = order;
        
        Items = new OrderItemCollection(_order);
    }
}
