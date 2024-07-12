using Store.Data;

namespace Store;

public class OrderItem
{
    internal readonly OrderItemData _orderItemData;
    public int ItemId => _orderItemData.ItemId;
    
    public int Count
    {
        get => _orderItemData.Count;
        set => _orderItemData.ChangeCount(value);
    }

    public float Price
    {
        get => _orderItemData.Price;
        set => _orderItemData.Price = value;
    }

    public OrderItem(OrderItemData orderItemDataData)
    {
        _orderItemData = orderItemDataData;
    }
}