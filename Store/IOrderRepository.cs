namespace Store;

public interface IOrderRepository
{
    public Order CreateOrder();
    public Order? GetById(int id);
    public void UpdateOrder(Order order);
}