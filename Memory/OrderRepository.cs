using Store;

namespace Memory;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];
    
    public Order CreateOrder()
    {
        var nextId = _orders.Count + 1;
        var order = new Order(nextId, Array.Empty<OrderItem>());
        
        _orders.Add(order);

        return order;
    }

    public Order GetById(int id)
    {
        return _orders.Single(order => order.Id == id);
    }

    public void UpdateOrder(Order order)
    {
        
    }
}