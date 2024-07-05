using Store;

namespace Tests;

public class OrderTests
{
    [Fact]
    public void Order_WithNullItems_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Order(1, null!));
    }
    
    [Fact]
    public void TotalCount_WithEmptyItems_ReturnsZero()
    {
        var order = new Order(1, Array.Empty<OrderItem>());
        
        Assert.Equal(0, order.TotalCount);
    }
    
    [Fact]
    public void TotalCount_WithNonEmptyItems_CalculatesTotalCount()
    {
        const int firstItemCount = 3;
        const int secondItemCount = 5;
        
        var order = new Order(1, new []
        {
            new OrderItem(1,firstItemCount,10),
            new OrderItem(2,secondItemCount,100)
        });
        
        Assert.Equal(firstItemCount + secondItemCount, order.TotalCount);
    }
    
    [Fact]
    public void TotalPrice_WithNonEmptyItems_CalculatesTotalCount()
    {
        const int firstItemCount = 3;
        const int firstItemPrice = 10;
        
        const int secondItemCount = 5;
        const int secondItemPrice = 100;
        
        var order = new Order(1, new []
        {
            new OrderItem(1,firstItemCount,firstItemPrice),
            new OrderItem(2,secondItemCount,secondItemPrice)
        });
        
        Assert.Equal(firstItemCount * firstItemPrice + secondItemCount * secondItemPrice, order.TotalPrice);
    }
}