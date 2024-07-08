using Store;
using Store.Data;

namespace Tests;

public class OrderTests
{
    private static Order CreateEmptyTestOrder()
    {
        return new Order(new OrderData
        {
            Id = 1,
            Items = Array.Empty<OrderItemData>()
        });
    }
    
    [Fact]
    public void TotalCount_WithEmptyItems_ReturnsZero()
    {
        var order = CreateEmptyTestOrder();
        
        Assert.Equal(0, order.TotalCount);
    }
    
    [Fact]
    public void TotalCount_WithNonEmptyItems_CalculatesTotalCount()
    {
        const int firstItemCount = 3;
        const int secondItemCount = 5;

        var order = CreateTestOrder();
        
        order.Items.First(x => x.ItemId == 1).Count = firstItemCount;
        order.Items.First(x => x.ItemId == 2).Count = secondItemCount;
        
        Assert.Equal(firstItemCount + secondItemCount, order.TotalCount);
    }

    private static Order CreateTestOrder()
    {
        var order = new Order(new OrderData
        {
            Id = 1,
            Items = new[]
            {
                new OrderItemData { ItemId = 1, Price = 1, Count = 1 },
                new OrderItemData { ItemId = 2, Price = 2, Count = 2 }
            }
        });
        return order;
    }

    [Fact]
    public void TotalPrice_WithNonEmptyItems_CalculatesTotalCount()
    {
        const int firstItemCount = 3;
        const int firstItemPrice = 10;
        
        const int secondItemCount = 5;
        const int secondItemPrice = 100;

        var order = CreateTestOrder();
        
        var item1 = order.Items.First(x => x.ItemId == 1);
        var item2 = order.Items.First(x => x.ItemId == 2);

        item1.Count = firstItemCount;
        item1.Price = firstItemPrice;
        
        item2.Count = secondItemCount;
        item2.Price = secondItemPrice;
        
        Assert.Equal(firstItemCount * firstItemPrice + secondItemCount * secondItemPrice, order.TotalPrice);
    }
}