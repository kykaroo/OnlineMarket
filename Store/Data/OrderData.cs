namespace Store.Data;

public class OrderData
{
    public int Id { get; set; }
    public int TotalCount { get; set; }
    public float TotalPrice { get; set; }
    public IList<OrderItemData> Items { get; set; } = new List<OrderItemData>();
}