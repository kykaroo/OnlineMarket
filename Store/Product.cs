namespace Store;

public class Product(int id, string title, int price)
{
    public int Id { get; } = id;
    public string Title { get; } = title;
    public int Price { get; } = price;
}