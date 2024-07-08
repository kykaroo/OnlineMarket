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

    public OrderItem Add(int itemId, int count, float price)
    {
        if (TryGet(itemId, out var orderItem))
            throw new InvalidOperationException("Book already exists.");

        var orderItemData = OrderItemFactory.Create(_orderData, itemId, count, price);
        
        _orderData.Items.Add(orderItemData);
        
        orderItem = OrderItemMapper.Map(orderItemData);
        _items.Add(orderItem);

        return orderItem;
    }

    public bool TryRemoveAllItems(int itemId)
    {
        var orderItem = Get(itemId);
        
        if (orderItem == null) return false;
        
        _items.Remove(orderItem);
        return true;
    }
    
    public bool TryRemoveItems(int itemId, int count)
    {
        var orderItem = Get(itemId);

        if (orderItem == null) return false;

        if (orderItem.Count <= count)
        {
            _items.Remove(orderItem);
            return true;
        }

        orderItem.Count -= count;
        return true;
    }
}