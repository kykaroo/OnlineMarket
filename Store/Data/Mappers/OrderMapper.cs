namespace Store.Data.Mapper;

public class OrderMapper
{
    public static Order Map(OrderData orderData) => new Order(orderData);
}