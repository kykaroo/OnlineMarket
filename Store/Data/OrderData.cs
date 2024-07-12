namespace Store.Data;

public class OrderData
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int TotalCount { get; set; }
    public float TotalPrice { get; set; }
    public IEnumerable<OrderItemData> Items => _items;
    
    private IList<OrderItemData> _items { get; } = new List<OrderItemData>();

    public void AddItem(OrderItemData orderItemData)
    {
        _items.Add(orderItemData);
        TotalPrice += orderItemData.Price * orderItemData.Count;
        TotalCount += orderItemData.Count;
    }

    public void RemoveItem(OrderItemData orderItemData)
    {
        var item = _items.First(item => item.ItemId == orderItemData.ItemId);
        TotalPrice -= item.Price * item.Count;
        TotalCount -= item.Count;
        _items.Remove(orderItemData);
    }
}