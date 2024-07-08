namespace Store.Data.Factories;

public static class OrderItemFactory
{
    public static OrderItemData Create(OrderData orderData, int itemId, int count, float price)
    {
        if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater then zero");

        return new OrderItemData
        {
            ItemId = itemId,
            Count = count,
            Price = price,
            Order = orderData
        };
    }
}