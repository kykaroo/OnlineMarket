using Microsoft.EntityFrameworkCore;
using Store;
using Store.Data.Factories;
using Store.Data.Mapper;

namespace Data;

public class OrderRepository(DbContextFactory dbContextFactory) : IOrderRepository
{
    public Order CreateOrder()
    {
        var dbContext = dbContextFactory.Create(typeof(OrderRepository));
        var data = OrderDataFactory.Create();

        dbContext.Orders.Add(data);
        dbContext.SaveChanges();

        return OrderMapper.Map(data);
    }

    public Order? GetById(int id)
    {
        var dbContext = dbContextFactory.Create(typeof(OrderRepository));
        
        var data = dbContext.Orders.Include(order => order.Items).Single(order => order.Id == id);

        return OrderMapper.Map(data);
    }

    public void UpdateOrder(Order order)
    {
        var dbContext = dbContextFactory.Create(typeof(OrderRepository));

        dbContext.SaveChanges();
    }
}