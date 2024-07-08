namespace Store.Data.Mapper;

public static class OrderItemMapper
{
    public static OrderItem Map(OrderItemData orderItemData) => new OrderItem(orderItemData);
    public static OrderItemData Map(OrderItem orderItem) => orderItem._orderItemData;
}