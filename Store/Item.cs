using System.Text.RegularExpressions;
using Store.Data;

namespace Store;

public class Item(ItemData item)
{
    internal readonly ItemData _item = item;
    public int Id => _item.Id;
    public string Title
    {
        get => _item.Title;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            
            _item.Title = value;
        }
    }

    public string Description
    {
        get => _item.Description;
        set => _item.Description = value;
    }

    public float Price
    {
        get => _item.Price;
        set => _item.Price = value;
    }

    public int Stock
    {
        get => _item.Stock;
        set => _item.Stock = value;
    }

    public bool AdultOnly
    {
        get => _item.AdultOnly;
        set => _item.AdultOnly = value;
    }

    public static bool IsId(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return false;
        }

        query = query.Replace("-", "").Replace(" ", "").ToUpper();

        return Regex.IsMatch(query, @"^ID\d*$");
    }
}