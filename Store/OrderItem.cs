namespace Store;

public class OrderItem
{
    public int ProductId { get; }
    public int Count { get; }
    public float Price { get; }

    public OrderItem(int productId, int count, float price)
    {
        if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), "Count must be greather then zero");
        
        ProductId = productId;
        Count = count;
        Price = price;
    }
}