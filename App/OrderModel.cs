namespace App;

public class OrderModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public OrderItemModel[] Items { get; set; } = [];
    public int TotalCount { get; set; }
    public float TotalPrice { get; set; }
}