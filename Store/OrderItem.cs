using Store.Data;

namespace Store;

public class OrderItem
{
    internal readonly OrderItemData _orderItemData;
    public int ItemId => _orderItemData.ItemId;
    
    public int Count
    {
        get => _orderItemData.Count;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "Count must be greater then zero");
            _orderItemData.Count = value;
        }
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