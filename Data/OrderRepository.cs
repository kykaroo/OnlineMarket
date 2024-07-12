using Microsoft.EntityFrameworkCore;
using Store;
using Store.Data.Factories;
using Store.Data.Mapper;

namespace Data;

public class OrderRepository(DbContextFactory dbContextFactory) : IOrderRepository
{
    public Order CreateOrder(string userName)
    {
        var dbContext = dbContextFactory.Create(typeof(OrderRepository));
        var data = OrderDataFactory.Create();

        data.UserName = userName;
        dbContext.Orders.Add(data);
        dbContext.SaveChanges();

        return OrderMapper.Map(data);
    }

    public Order? GetById(int id)
    {
        var dbContext = dbContextFactory.Create(typeof(OrderRepository));

        var data = dbContext.Orders.Include(order => order.Items);
        
        var item = data.Single(order => order.Id == id);

        return OrderMapper.Map(item);
    }

    public void UpdateOrder(Order order)
    {
        var dbContext = dbContextFactory.Create(typeof(OrderRepository));

        dbContext.SaveChanges();
    }

    public Order? GetByUserName(string userName)
    {
        var dbContext = dbContextFactory.Create(typeof(OrderRepository));
        
        var data = dbContext.Orders.Include(order => order.Items);

        var item = data.SingleOrDefault(order => string.Equals(order.UserName, userName));

        return item == null ? null : OrderMapper.Map(item);
    }
}