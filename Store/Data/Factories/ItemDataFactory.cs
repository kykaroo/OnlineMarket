namespace Store.Data.Factories;

public static class ItemDataFactory
{
    public static ItemData Create(string title, string description, float price, int stock, bool adultOnly)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(string.Empty, nameof(title));
        }

        return new ItemData
        {
            Title = title,
            Description = description,
            Price = price,
            Stock = stock,
            AdultOnly = adultOnly
        };
    }
}