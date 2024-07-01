using System.Text.RegularExpressions;

namespace Store;

public class Product(int id, string title, int price, int stock, bool adultOnly, string description)
{
    public int Id { get; } = id;
    public string Title { get; } = title;
    public int Price { get; } = price;
    public int Stock { get; } = stock;
    public bool AdultOnly { get; } = adultOnly;
    public string Description { get; } = description;

    internal static bool IsId(string query)
    {
        if (query == null)
        {
            return false;
        }

        query = query.Replace("-", "").Replace(" ", "").ToUpper();

        return Regex.IsMatch(query, @"ID\d*");
    }
}