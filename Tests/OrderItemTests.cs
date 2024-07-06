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

    [Fact]
    public void Count_WithPositiveValue_SetsValue()
    {
        var orderItem = new OrderItem(0, 5, 0);
        const int countToValid = 10;
        
        orderItem.Count = countToValid;

        Assert.Equal(countToValid, countToValid);
    }

    [Fact]
    public void Count_WithNegativeValue_ThrowsArgumentOutOfRangeException()
    {
        var orderItem = new OrderItem(0, 5, 0);
        const int countToValid = -1;

        Assert.Throws<ArgumentOutOfRangeException>(() => orderItem.Count = countToValid);
    }
    
    [Fact]
    public void Count_WithZeroValue_ThrowsArgumentOutOfRangeException()
    {
        var orderItem = new OrderItem(0, 5, 0);
        const int countToValid = 0;

        Assert.Throws<ArgumentOutOfRangeException>(() => orderItem.Count = countToValid);
    }
}