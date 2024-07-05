using Store;

namespace Tests;

public class OrderItemTests
{
    [Fact]
    public void OrderItem_WithZeroCount_ThrowArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, 0, 0));
    }
    
    [Fact]
    public void OrderItem_WithNegativeCount_ThrowArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, -1, 0));
    }
    
    [Fact]
    public void OrderItem_WithPositiveCount_SetsCount()
    {
        var orderItem = new OrderItem(1,2,3);
        
        Assert.Equal(1, orderItem.ProductId);
        Assert.Equal(2, orderItem.Count);
        Assert.Equal(3, orderItem.Price);
    }
}