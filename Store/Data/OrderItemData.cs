namespace Store.Data;

public class OrderItemData
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public OrderData Order { get; set; }
}