namespace Store.Data;

public class OrderItemData
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int Count { get; private set; }
    public float Price { get; set; }
    public OrderData Order { get; set; }

    public void ChangeCount(int newValue)
    {
        if (newValue <= 0) throw new ArgumentOutOfRangeException(nameof(newValue), "Count must be greater then zero");

        int difference;

        if (Count == 0)
        {
            Count = newValue;
            return;
        }
        
        if (Count > newValue)
        {
            difference = Count - newValue;
            Order.TotalCount -= difference;
            Order.TotalPrice -= difference * Price;
        }
        else
        {
            difference = newValue - Count;
            Order.TotalCount += difference;
            Order.TotalPrice += difference * Price;
        }
        
        Count = newValue;
    }
}