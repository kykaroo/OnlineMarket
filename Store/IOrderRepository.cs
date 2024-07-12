namespace Store;

public interface IOrderRepository
{
    public Order CreateOrder(string userName);
    public Order? GetById(int id);
    public void UpdateOrder(Order order);
    public Order? GetByUserName(string userName);
}