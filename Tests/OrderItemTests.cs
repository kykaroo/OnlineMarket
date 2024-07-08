using Store;
using Store.Data;
using Store.Data.Factories;
using Store.Data.Mapper;

namespace Tests;

public class OrderItemTests
{
    [Fact]
    public void OrderItem_WithZeroCount_ThrowArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            const int count = 0;
            OrderItemFactory.Create(new OrderData(), 1, count, 10);
        });
    }
    
    [Fact]
    public void OrderItem_WithNegativeCount_ThrowArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            const int count = -1;
            OrderItemFactory.Create(new OrderData(), 1, count, 10);
        });
    }
    
    [Fact]
    public void OrderItem_WithPositiveCount_SetsCount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            const int count = 0;
            OrderItemFactory.Create(new OrderData(), 1, count, 10);
        });
    }

    [Fact]
    public void Count_WithPositiveValue_SetsValue()
    {
        var orderItemData = OrderItemFactory.Create(new OrderData(), 1, 1, 1);
        var orderItem = OrderItemMapper.Map(orderItemData);
        const int countToValid = 1;
        
        orderItem.Count = countToValid;

        Assert.Equal(countToValid, orderItem.Count);
    }

    [Fact]
    public void Count_WithNegativeValue_ThrowsArgumentOutOfRangeException()
    {
        var orderItemData = OrderItemFactory.Create(new OrderData(), 1, 1, 1);
        var orderItem = OrderItemMapper.Map(orderItemData);
        const int countToValid = -1;

        Assert.Throws<ArgumentOutOfRangeException>(() => orderItem.Count = countToValid);
    }
    
    [Fact]
    public void Count_WithZeroValue_ThrowsArgumentOutOfRangeException()
    {
        var orderItemData = OrderItemFactory.Create(new OrderData(), 1, 1, 1);
        var orderItem = OrderItemMapper.Map(orderItemData);
        const int countToValid = 0;

        Assert.Throws<ArgumentOutOfRangeException>(() => orderItem.Count = countToValid);
    }
}