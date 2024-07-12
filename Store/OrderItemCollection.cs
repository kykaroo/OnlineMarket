using System.Collections;
using Store.Data;
using Store.Data.Factories;
using Store.Data.Mapper;

namespace Store;

public class OrderItemCollection : IReadOnlyCollection<OrderItem>
{
    private readonly OrderData _orderData;
    private readonly List<OrderItem> _items;

    public OrderItemCollection(OrderData orderData)
    {
        ArgumentNullException.ThrowIfNull(orderData);

        _orderData = orderData;

        _items = orderData.Items.Select(OrderItemMapper.Map).ToList();
    }

    public int Count => _items.Count;

    public IEnumerator<OrderItem> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (_items as IEnumerable).GetEnumerator();
    }

    public OrderItem? Get(int bookId)
    {
        if (TryGet(bookId, out var orderItem))
            return orderItem;

        return null;
    }

    public bool TryGet(int itemId, out OrderItem orderItem)
    {
        var index = _items.FindIndex(item => item.ItemId == itemId);
        if (index == -1)
        {
            orderItem = null;
            return false;
        }

        orderItem = _items[index];
        return true;
    }

    public OrderItem AddItem(int itemId, int count, decimal price)
    {
        if (TryGet(itemId, out var orderItem))
            throw new InvalidOperationException("Item already exists.");

        var orderItemData = OrderItemFactory.Create(_orderData, itemId, count, price);
        
        _orderData.AddItem(orderItemData);
        
        orderItem = OrderItemMapper.Map(orderItemData);
        _items.Add(orderItem);

        return orderItem;
    }

    public bool TryRemoveAllItems(int itemId)
    {
        var orderItem = Get(itemId);
        
        if (orderItem == null) return false;

        RemoveAllItems(orderItem);
        return true;
    }
    
    public bool TryRemoveItems(int itemId, int count)
    {
        var orderItem = Get(itemId);

        if (orderItem == null) return false;

        if (orderItem.Count <= count)
        {
            RemoveAllItems(orderItem);
            return true;
        }
        
        orderItem.Count -= count;
        return true;
    }

    private void RemoveAllItems(OrderItem orderItem)
    {
        var orderItemData = OrderItemMapper.Map(orderItem);
        
        orderItemData.Order.RemoveItem(orderItemData);
        _items.Remove(orderItem);
    }
}