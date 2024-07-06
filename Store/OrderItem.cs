namespace Store;

public class OrderItem
{
    public int ItemId { get; }

    private int _count;
    public int Count
    {
        get => _count;
        set
        {
            ThrowIfInvalidCount(value);
            _count = value;
        }
    }

    public float Price { get; }

    public OrderItem(int itemId, int count, float price)
    {
        ThrowIfInvalidCount(count);
        
        ItemId = itemId;
        Count = count;
        Price = price;
    }

    private static void ThrowIfInvalidCount(int count)
    {
        if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater then zero");
    }
}